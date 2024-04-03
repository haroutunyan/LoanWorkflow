using LoanWorkflow.Services.Ekeng;
using LoanWorkflow.Services.Interfaces.Ekeng;
using Microsoft.Extensions.DependencyInjection;

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

            if (!string.IsNullOrEmpty(options.EkengUrl))
            {
                services.AddHttpContextAccessor();
                services.AddHttpClient<IEkengService, EkengService>((provider, client) =>
                {
                    client.BaseAddress = new Uri(options.EkengUrl);
                });
            }

            ServicesRegistrator.Register(services);
            return services;
        }
    }
}