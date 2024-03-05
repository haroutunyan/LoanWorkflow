using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace LoanWorkflow.Api.Middlewares
{
    public class MaintenanceCheckingMiddleware(
        RequestDelegate next, 
        IConfiguration configuration)
    {
        public async Task Invoke(HttpContext context)
        {
            switch (configuration.GetValue<int>("Maintenance"))
            {
                case 1:
                    context.Response.StatusCode = StatusCodes.Status503ServiceUnavailable;
                    return;
                default:
                    await next(context);
                    break;
            }
        }
    }
}
