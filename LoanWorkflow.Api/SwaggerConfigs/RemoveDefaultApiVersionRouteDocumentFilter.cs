using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace LoanWorkflow.Api.SwaggerConfigs
{
    public class RemoveDefaultApiVersionRouteDocumentFilter : IDocumentFilter
    {
        public void Apply(OpenApiDocument swaggerDoc, DocumentFilterContext context)
        {
            foreach (var apiDescription in context.ApiDescriptions)
            {
                var pathContainsVersionNumber = apiDescription.RelativePath.Contains("v1") ||
                                                apiDescription.RelativePath.Contains("v2");

                if (pathContainsVersionNumber)
                    continue;

                var route = "/" + apiDescription.RelativePath.TrimEnd('/');
                swaggerDoc.Paths.Remove(route);
            }
        }
    }
}
