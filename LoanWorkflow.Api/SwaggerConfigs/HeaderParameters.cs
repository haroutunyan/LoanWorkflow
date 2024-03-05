using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace LoanWorkflow.Api.SwaggerConfigs
{
    public class HeaderParameters : IOperationFilter
    {
        public void Apply(OpenApiOperation operation, OperationFilterContext context)
        {
            operation.Parameters ??= [];
            operation.Parameters.Add(new OpenApiParameter()
            {
                Name = "x-deviceid",
                Description = "Device Id",
                In = ParameterLocation.Header,
                Schema = new OpenApiSchema() { Type = "string" },
                AllowEmptyValue = false,
                Required = true,
                Example = new OpenApiString("yiusdkdieebdfjhdgk")
            });
        }
    }
}
