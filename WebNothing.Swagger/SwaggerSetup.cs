using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using System.IO;

namespace WebNothing.Swagger
{
    public static class SwaggerSetup
    {
        public static IServiceCollection AddSwaggerConfiguration(this IServiceCollection services)
        {
            return services.AddSwaggerGen( opt =>
            {
                opt.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "WebApp .NET Core",
                    Version = "v1",
                    Description = "Just a web application to learn Angular + .NET"
                });

                string xmlPath = Path.Combine("wwwroot", "api-doc.xml");

                opt.IncludeXmlComments(xmlPath);

            });
        }

        public static IApplicationBuilder UseSwaggerConfiguration(this IApplicationBuilder app)
        {
            return app.UseSwagger().UseSwaggerUI(d => {

                d.RoutePrefix = "documentation";
                d.SwaggerEndpoint("../swagger/v1/swagger.json", "API v1");

            });
        }
    }
}
