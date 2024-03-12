using LoanWorkflow.Core.Exceptions;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace LoanWorkflow.Api.ExceptionHandler
{
    internal sealed class LoanWorkflowExceptionHandler : IExceptionHandler
    {
        public async ValueTask<bool> TryHandleAsync(
            HttpContext httpContext, 
            Exception exception,
            CancellationToken cancellationToken)
        {
            var errorResponse = new ProblemDetails
            {
                Title = exception.GetType().Name,
                Status = exception switch
                {
                    UnauthorizedException => (int)HttpStatusCode.Unauthorized,
                    LoanWorkflowException => (int)HttpStatusCode.OK,
                    _ => (int?)(int)HttpStatusCode.InternalServerError,
                }
            };

            httpContext.Response.StatusCode = errorResponse.Status.Value;
            await httpContext.Response
                .WriteAsJsonAsync(errorResponse, cancellationToken);

            return true;
        }
    }
}
