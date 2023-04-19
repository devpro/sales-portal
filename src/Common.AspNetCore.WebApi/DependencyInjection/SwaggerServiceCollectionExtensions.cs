using Devpro.Common.AspNetCore.WebApi.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Devpro.Common.AspNetCore.WebApi.DependencyInjection
{
    public static class SwaggerServiceCollectionExtensions
    {
        public static IServiceCollection AddSwagger(this IServiceCollection services, WebApiConfiguration configuration)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc(configuration.OpenApi.Version, configuration.OpenApi);
            });

            return services;
        }
    }
}
