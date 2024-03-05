using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Primitives;

namespace LoanWorkflow.Services.Core
{
    public static class Extensions
    {
        public static IServiceCollection ConfigureCoreBLL(
            this IServiceCollection services,
            Action<BLLConfigurationBuilder> setupAction)
        {
            var options = new BLLConfigurationBuilder();
            setupAction?.Invoke(options ?? throw new ArgumentNullException(nameof(setupAction)));

            if (!string.IsNullOrEmpty(options.UnionUrl))
            {
                services.AddHttpContextAccessor();
                services.AddHttpClient<ITempService, TempService>((provider, client) =>
                {
                    const string corellationHeader = "X-Correlation-ID";
                    var context = provider.GetRequiredService<IHttpContextAccessor>();
                    var header = new StringValues();

                    if (!context.HttpContext.Request.Headers.TryGetValue(corellationHeader, out header))
                    {
                        client.DefaultRequestHeaders.Add(corellationHeader, context.HttpContext.TraceIdentifier);
                    }
                    client.BaseAddress = new Uri(options.UnionUrl);
                });
            }

            ServicesRegistrator.Register(services);
            return services;
        }
    }

    public interface ITempService { }
    public class TempService : ITempService { }
}