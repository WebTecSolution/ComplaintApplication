using Microsoft.AspNetCore.Authorization;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ComplaintsApplication.ReadWrite.API
{
    public class OAuthOperationFilter : IOperationFilter
    {        
        public void Apply(OpenApiOperation operation, OperationFilterContext context)
        {
            var isAuthorized = context.MethodInfo.DeclaringType.GetCustomAttributes(true).OfType<AuthorizeAttribute>().Any() ||
                context.MethodInfo.GetCustomAttributes(true).OfType<AuthorizeAttribute>().Any();
            if (!isAuthorized) return;
            operation.Responses.TryAdd("401", new OpenApiResponse { Description = "Unauthorized" });
            operation.Responses.TryAdd("403", new OpenApiResponse { Description = "Forbidden" });
            var basicSecurityScheme = new OpenApiSecurityScheme()
            {
                Reference = new OpenApiReference { Type = ReferenceType.SecurityScheme, Id = "basic" },
            };
            operation.Security.Add(new OpenApiSecurityRequirement()
            {
                [basicSecurityScheme] = new string[] {
                                                        "ComplaintsApplicationReadWrite",
                                                        "ComplaintsApplicationReadWrite.full_access",
                                                        "ComplaintsApplicationReadWrite.read_only",
                                                        "ComplaintsApplicationTransfer",
                                                        "ComplaintsApplicationTransfer.full_access",
                                                        "ComplaintsApplicationTransfer.read_only"
                                                    }
            });
        }
    }
}
