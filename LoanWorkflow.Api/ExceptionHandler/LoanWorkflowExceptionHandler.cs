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
            var errorResponse = new ProblemDetails();
            switch (exception)
            {
                case UnauthorizedException:
                    errorResponse.Status = (int)HttpStatusCode.Unauthorized;
                    errorResponse.Title = exception.GetType().Name;
                    break;
                case LoanWorkflowException:
                    errorResponse.Status = (int)HttpStatusCode.OK;
                    errorResponse.Title = exception.GetType().Name;                    
                    break;
                default:
                    errorResponse.Status = (int)HttpStatusCode.InternalServerError;
                    errorResponse.Title = "Internal Server Error";
                    break;
            }
            httpContext.Response.StatusCode = errorResponse.Status.Value;
            await httpContext.Response
                .WriteAsJsonAsync(errorResponse, cancellationToken);

            return true;
        }
    }
}
