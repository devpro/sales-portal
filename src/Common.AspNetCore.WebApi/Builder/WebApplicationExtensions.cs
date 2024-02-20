using Devpro.Common.AspNetCore.WebApi.Configuration;
using Microsoft.AspNetCore.Builder;

namespace Devpro.Common.AspNetCore.WebApi.Builder
{
    public static class WebApplicationExtensions
    {
        /// <summary>
        /// Add default middleware.
        /// </summary>
        /// <param name="app"></param>
        /// <param name="configuration"></param>
        /// <returns></returns>
        public static WebApplication AddDefaultMiddlewares(
            this WebApplication app,
            WebApiConfiguration configuration)
        {
            app.UseDeveloperExceptionPage(app.Environment);
            app.UseSwagger(configuration);
            app.UseHttps(configuration);
            app.UseAuthorization();
            app.UseCors(WebApiConfiguration.CorsPolicyName);
            app.MapControllers().RequireCors(WebApiConfiguration.CorsPolicyName);
            app.MapHealthChecks(WebApiConfiguration.HealthCheckEndpoint);

            return app;
        }
    }
}
