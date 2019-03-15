using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Newtonsoft.Json.Linq;
using Swashbuckle.AspNetCore.Swagger;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace Screend.Filters
{
    public class SwaggerLocationHeader : IOperationFilter
    {
        public void Apply(Operation operation, OperationFilterContext context)
        {
            if (operation.Tags.Contains("User") || operation.Tags.Contains("Location"))
            {
                return;
            }
            
            if (operation.Parameters == null)
                operation.Parameters = new List<IParameter>();
                         
            operation.Parameters.Add(HeaderParam("X-Location-Id", 1, false, "string", "Location Id"));       
        }

        public IParameter HeaderParam(string name, dynamic defaultValue, bool required = false, string type = "string", string description = "")
        {
            return new NonBodyParameter
            {
                Name = name,
                In = "header",
                Default = defaultValue,
                Type = type,
                Description = description,
                Required = required
            };
        }
    }
}