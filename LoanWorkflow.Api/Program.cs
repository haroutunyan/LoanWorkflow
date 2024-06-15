using LoanWorkflow.Services.Core;
using LoanWorkflow.DAL.Core;
using FluentValidation;
using FluentValidation.AspNetCore;
using LoanWorkflow.Core.Validations;
using LoanWorkflow.Api.Middlewares;
using Microsoft.AspNetCore.HttpOverrides;
using LoanWorkflow.Api.SwaggerConfigs;
using Microsoft.Extensions.Options;
using Swashbuckle.AspNetCore.SwaggerGen;
using Asp.Versioning;
using LoanWorkflow.Core.Extensions;
using LoanWorkflow.Api.Abstractions;
using System.Reflection;
using LoanWorkflow.Core.Options;
using LoanWorkflow.Services.Users;
using LoanWorkflow.Api.ExceptionHandler;
using LoanWorkflow.Core.Handlers;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddExceptionHandler<LoanWorkflowExceptionHandler>();
builder.Services.AddProblemDetails();
builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddAutoMapper(cfg => { },
    Assembly.GetAssembly(typeof(LoanWorkflow.Api.Mappings.AssemblyReference)));

builder.Services.ConfigureDal(dalOptions =>
{
    dalOptions.ConnectionString = builder.Configuration.GetConnectionString("DbConnectionString");
});
builder.Services.ConfigureCoreBLL(options =>
{
    options.EkengUrl = builder.Configuration["ExternalServices:EkengURL"];
    options.AcraUrl = builder.Configuration["ExternalServices:AcraURL"];
});
builder.Services.AddTransient<LoggingDelegatingHandler>();
builder.Services.AddScoped(typeof(ApiContext));
builder.Services.AddScoped(typeof(LoanWorkflowUserManager));

builder.Services.AddAuthorization();
builder.Services.AddCors();
builder.Services.AddTransient<IConfigureOptions<SwaggerGenOptions>, ConfigureSwaggerOptions>();
builder.Services.AddSwaggerGen(options =>
{
    options.OperationFilter<HeaderParameters>();
    options.DocumentFilter<RemoveDefaultApiVersionRouteDocumentFilter>();
});
builder.Services.AddApiVersioning(options =>
{
    options.ReportApiVersions = true;
    options.DefaultApiVersion = new ApiVersion(1, 0);
    options.AssumeDefaultVersionWhenUnspecified = true;
    options.ApiVersionReader = ApiVersionReader.Combine(
        new UrlSegmentApiVersionReader(),
        new HeaderApiVersionReader("api-version"));
})
    .AddMvc()
    .AddApiExplorer(options =>
    {
        options.GroupNameFormat = "'v'VVV";
        options.SubstituteApiVersionInUrl = true;
    });

builder.Services.AddValidatorsFromAssembly(typeof(LoanWorkflow.Api.Validations.AssemblyReference).Assembly);
builder.Services.AddFluentValidationAutoValidation(fv =>
{
    fv.DisableDataAnnotationsValidation = true;
    ValidatorOptions.Global.DisplayNameResolver = (type, member, expression) =>
    {
        if (member != null)
        {
            return $"{type.Name}.{member.Name}";
        }
        return null;
    };

    ValidatorOptions.Global.PropertyNameResolver = (type, member, expression) =>
    {
        if (member != null)
        {
            return $"{type.Name}.{member.Name}";
        }
        return null;
    };
    ValidatorOptions.Global.LanguageManager = new InternalLanguageManager();

})
    .AddFluentValidationClientsideAdapters();

builder.Services.ConfigureAuthentication(builder.Configuration);
builder.Services.ConfigureDocumentation();
builder.Services.AddAuthorization();

builder.Services.Configure<JwtSettings>(options => 
    builder.Configuration.GetSection(nameof(JwtSettings)).Bind(options));
builder.Services.Configure<LoginProviderSettings>(options =>
    builder.Configuration.GetSection(nameof(LoginProviderSettings)).Bind(options));
builder.Services.Configure<AcraCredentials>(options =>
    builder.Configuration.GetSection(nameof(AcraCredentials)).Bind(options));

var app = builder.Build();
app.UseSwagger();
app.UseSwaggerUI();
app.UseMiddleware<MaintenanceCheckingMiddleware>();
app.UseHttpsRedirection();
app.UseCors(configurePolicy =>
{
    configurePolicy
        .AllowAnyOrigin()
        .AllowAnyHeader()
        .AllowAnyMethod();
});
app.UseRouting();
app.UseForwardedHeaders(new ForwardedHeadersOptions
{
    ForwardedHeaders = ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto
});
app.UseCorrelationId();
app.UseAuthentication();
app.UseAuthorization();
app.UseExceptionHandler();
app.MapControllers();
app.Run();