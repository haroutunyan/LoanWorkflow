using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
