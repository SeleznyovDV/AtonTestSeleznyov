using System.Collections.Generic;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

public class AddRequiredHeaderParameter : IOperationFilter
{
    public void Apply(OpenApiOperation operation, OperationFilterContext context)
    {
        if (operation.Parameters == null)
            operation.Parameters = new List<OpenApiParameter>();

        operation.Parameters.Add(new OpenApiParameter
        {
            Name = "Login",
            In = ParameterLocation.Header,
            Required = true,
            Schema = new OpenApiSchema
            {
                Type = "string"
            }
        });
        
        operation.Parameters.Add(new OpenApiParameter
        {
            Name = "Password",
            In = ParameterLocation.Header,
            Required = true,
            Schema = new OpenApiSchema
            {
                Type = "string"
            }
        });
    }
}