using LoanWorkflow.Core.Handlers;
using LoanWorkflow.Services.Acra;
using LoanWorkflow.Services.Ekeng;
using LoanWorkflow.Services.Interfaces.Acra;
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

            services.AddHttpContextAccessor();
            services.AddHttpClient<IEkengService, EkengService>((provider, client) =>
            {
                client.BaseAddress = new Uri(options.EkengUrl);
            })
                .AddHttpMessageHandler<LoggingDelegatingHandler>();

            services.AddHttpClient<IAcraService, AcraService>((provider, client) =>
            {
                client.BaseAddress = new Uri(options.AcraUrl);
            })
                .ConfigurePrimaryHttpMessageHandler(() =>
            {
                var handler = new HttpClientHandler
                {
                    ClientCertificateOptions = ClientCertificateOption.Manual,
                    ServerCertificateCustomValidationCallback = (httpRequestMessage, cert, cetChain, policyErrors) => true
                };

                return handler;
            })
                .AddHttpMessageHandler<LoggingDelegatingHandler>();

            ServicesRegistrator.Register(services);
            return services;
        }
    }
}