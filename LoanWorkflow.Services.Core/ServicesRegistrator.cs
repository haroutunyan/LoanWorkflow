using Microsoft.Extensions.DependencyInjection;

namespace LoanWorkflow.Services.Core
{
    internal partial class ServicesRegistrator
    {
        internal static IServiceCollection Register(IServiceCollection services)
        {
            foreach (var entry in servicesDescriptors)
            {
                services.Add(entry);
            }
            return services;
        }
        private class InternalServiceDescriptor(
            Type serviceType,
            Type implementationType,
            ServiceLifetime lifetime = ServiceLifetime.Scoped) 
            : ServiceDescriptor(serviceType, implementationType, lifetime)
        {
        }
    }
}
