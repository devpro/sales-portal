using Devpro.Common.AspNetCore.WebApi.Configuration;
using Microsoft.AspNetCore.Builder;

namespace Devpro.Common.AspNetCore.WebApi.Builder
{
    public static class SwaggerBuilderExtensions
    {
        public static IApplicationBuilder UseSwagger(this IApplicationBuilder app, WebApiConfiguration configuration)
        {
            if (configuration.IsSwaggerEnabled)
            {
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint($"/swagger/{configuration.OpenApi.Version}/swagger.json",
                    $"{configuration.OpenApi.Title} {configuration.OpenApi.Version}"));
            }

            return app;
        }
    }
}
