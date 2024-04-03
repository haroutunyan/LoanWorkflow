using LoanWorkflow.Core.Options;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace LoanWorkflow.Core.Middlewares
{
    public class CorrelationIdMiddleware
    {
        private readonly RequestDelegate next;

        private readonly CorrelationIdOptions options;

        public CorrelationIdMiddleware(RequestDelegate next, CorrelationIdOptions options)
        {
            ArgumentNullException.ThrowIfNull(options);

            this.next = next ?? throw new ArgumentNullException(nameof(next));
            this.options = options;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            if (context.Request.Headers.TryGetValue(options.Header, out var value))
            {
                context.TraceIdentifier = value;
            }
            else
            {
                context.TraceIdentifier = Guid.NewGuid().ToString("N");
            }

            if (options.IncludeInResponse)
            {
                context.Response.OnStarting(async delegate
                {
                    context.Response.Headers.Add(options.Header, new string[1] { context.TraceIdentifier });
                    await Task.CompletedTask;
                });
            }

            await next(context);
        }
    }
}
