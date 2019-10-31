using Swashbuckle.AspNetCore.Swagger;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.Collections.Generic;

namespace SwaggerDemo.Filters
{
    public class HeadersFilter : IOperationFilter
    {
        public void Apply(Operation operation, OperationFilterContext context)
        {
           if(operation.Parameters==null)
            {
                operation.Parameters = new List<IParameter>(); 
            }

            operation.Parameters.Add(new NonBodyParameter()
            {
                Description="User ID:",
                In="header",
                Name="User ID",
                Required=false
            });
        }
    }
}
