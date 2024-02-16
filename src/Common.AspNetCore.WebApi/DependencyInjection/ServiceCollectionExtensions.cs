using Devpro.Common.AspNetCore.WebApi.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Devpro.Common.AspNetCore.WebApi.DependencyInjection
{
    public static class ServiceCollectionExtensions
    {
        /// <summary>
        /// Add default services in the service collection.
        /// </summary>
        /// <param name="services"></param>
        /// <param name="configuration"></param>
        /// <param name="loggingBuilder"></param>
        /// <returns></returns>
        /// <see cref="ConfigurationConstants"/>
        public static IServiceCollection AddDefaultServices(this IServiceCollection services, WebApiConfiguration configuration, ILoggingBuilder loggingBuilder)
        {
            services.AddCors(WebApiConfiguration.CorsPolicyName, configuration.CorsAllowedOrigin);
            services.AddControllers();
            services.AddEndpointsApiExplorer();
            services.AddSwagger(configuration);
            services.AddHealthChecks();
            services.AddOpenTelemetry(configuration, loggingBuilder);

            return services;
        }
    }
}
