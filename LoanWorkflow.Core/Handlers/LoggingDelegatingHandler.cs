using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanWorkflow.Core.Handlers
{
    public class LoggingDelegatingHandler : DelegatingHandler
    {
        public LoggingDelegatingHandler()
        {

        }

        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            var httpResponseMessage = await base.SendAsync(request, cancellationToken);
            httpResponseMessage.EnsureSuccessStatusCode();

            return httpResponseMessage;
        }
    }
}
