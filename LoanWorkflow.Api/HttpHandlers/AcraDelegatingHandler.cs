using LoanWorkflow.Core.Options;
using Microsoft.Extensions.Options;

namespace LoanWorkflow.Api.HttpHandlers
{
    public class AcraDelegatingHandler(
        IOptions<AcraCredentials> options) : DelegatingHandler
    {
        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            return base.SendAsync(request, cancellationToken);
        }
    }
}
