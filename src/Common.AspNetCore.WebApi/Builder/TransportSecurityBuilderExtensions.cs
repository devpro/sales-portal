using Devpro.Common.AspNetCore.WebApi.Configuration;
using Microsoft.AspNetCore.Builder;

namespace Devpro.Common.AspNetCore.WebApi.Builder
{
    public static class TransportSecurityBuilderExtensions
    {
        public static IApplicationBuilder UseHttps(this IApplicationBuilder app, WebApiConfiguration configuration)
        {
            if (configuration.IsHttpsRedirectionEnabled)
            {
                app.UseHttpsRedirection();
            }

            return app;
        }
    }
}
