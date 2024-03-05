using Microsoft.AspNetCore.Cors.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime;
using System.Text;
using System.Threading.Tasks;

namespace LoanWorkflow.Services.Core
{
    internal partial class ServicesRegistrator
    {
        private static IEnumerable<InternalServiceDescriptor> servicesDescriptors = [];
    }
}
