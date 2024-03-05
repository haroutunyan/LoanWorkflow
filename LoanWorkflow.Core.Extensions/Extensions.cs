using LoanWorkflow.Core.Middlewares;
using LoanWorkflow.Core.Options;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanWorkflow.Core.Extensions
{
    public static class Extensions
    {
        public static void ConfigureDocumentation(this IServiceCollection services)
        {
            services.AddSwaggerGen(setup =>
            {
                var jwtSecurityScheme = new OpenApiSecurityScheme
                {
                    Scheme = "bearer",
                    BearerFormat = "JWT",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.Http,
                    Description = "JWT Authorization header using the Bearer scheme. \r\n\r\n Enter 'Bearer' [space] and then your token in the text input below.\r\n\r\nExample: \"12345abcdef\"",

                    Reference = new OpenApiReference
                    {
                        Id = JwtBearerDefaults.AuthenticationScheme,
                        Type = ReferenceType.SecurityScheme
                    }
                };

                setup.AddSecurityDefinition(jwtSecurityScheme.Reference.Id, jwtSecurityScheme);
                setup.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    { jwtSecurityScheme, Array.Empty<string>() }
                });

            });
        }

        public static void ConfigureAuthentication(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(cfg =>
            {
                cfg.TokenValidationParameters = new TokenValidationParameters()
                {

                    ValidateIssuer = Convert.ToBoolean(configuration.GetSection("JwtSettings").GetValue<string>("LoginProviderName")),
                    ValidIssuer = configuration.GetSection("JwtSettings").GetValue<string>("Issuer"),
                    ValidateAudience = Convert.ToBoolean(configuration.GetSection("JwtSettings").GetValue<string>("LoginProviderKey")),
                    ValidAudience = configuration.GetSection("JwtSettings").GetValue<string>("Audience"),
                    ValidateIssuerSigningKey = Convert.ToBoolean(configuration.GetSection("JwtSettings").GetValue<string>("TokenName")),
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8
                     .GetBytes(configuration.GetSection("JwtSettings").GetValue<string>("SecretKey"))),
                    ClockSkew = TimeSpan.Zero,
                    LifetimeValidator = (notBefore, expires, securityToken, validationParameters) =>
                    {
                        return expires != null && expires > DateTime.UtcNow;
                    }
                };
            });
        }

        public static IApplicationBuilder UseCorrelationId(this IApplicationBuilder app)
        {
            ArgumentNullException.ThrowIfNull(app);
            return app.UseMiddleware<CorrelationIdMiddleware>([new CorrelationIdOptions()]);
        }
    }
}
