using System;
using System.Linq;
using Devpro.Common.AspNetCore.WebApi.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using OpenTelemetry.Logs;
using OpenTelemetry.Metrics;
using OpenTelemetry.Resources;
using OpenTelemetry.Trace;

namespace Devpro.Common.AspNetCore.WebApi.DependencyInjection
{
    /// <summary>
    /// See https://opentelemetry.io/docs/instrumentation/net/getting-started/, https://github.com/open-telemetry/opentelemetry-dotnet
    /// </summary>
    public static class OpenTelemetryServiceCollectionExtensions
    {
        public static IServiceCollection AddOpenTelemetry(this IServiceCollection services, WebApiConfiguration configuration, ILoggingBuilder logging)
        {
            if (!configuration.IsOpenTelemetryEnabled)
            {
                return services;
            }

            ArgumentNullException.ThrowIfNull(logging);

            services.AddOpenTelemetry()
                .WithTracing(tracerProviderBuilder =>
                    tracerProviderBuilder
                        .AddSource(configuration.OpenTelemetryService)
                        .ConfigureResource(resourceBuilder => resourceBuilder
                            .AddService(configuration.OpenTelemetryService))
                        .AddAspNetCoreInstrumentation(options =>
                        {
                            options.Filter = (httpContext) =>
                            {
                                var pathsToIgnore = "/health,/favicon.ico";
                                return !pathsToIgnore.Split(',').Any(path => httpContext.Request.Path.StartsWithSegments(path));
                            };
                        })
                        .AddHttpClientInstrumentation()
                        .AddOtlpExporter(options => options.Endpoint = new Uri(configuration.OpenTelemetryCollectorEndpoint)))
                .WithMetrics(metricsProviderBuilder =>
                    metricsProviderBuilder
                        .ConfigureResource(resourceBuilder => resourceBuilder
                            .AddService(configuration.OpenTelemetryService))
                        .AddRuntimeInstrumentation()
                        .AddAspNetCoreInstrumentation()
                        .AddHttpClientInstrumentation()
                        .AddOtlpExporter(options => options.Endpoint = new Uri(configuration.OpenTelemetryCollectorEndpoint)));

            // logs
            logging.AddOpenTelemetry(loggerOptions =>
            {
                loggerOptions.SetResourceBuilder(ResourceBuilder.CreateDefault().AddService(configuration.OpenTelemetryService));
                loggerOptions.IncludeFormattedMessage = true;
                loggerOptions.IncludeScopes = true;
                loggerOptions.ParseStateValues = true;
                loggerOptions.AddOtlpExporter(
                    "logging",
                    options => options.Endpoint = new Uri(configuration.OpenTelemetryCollectorEndpoint));
            });

            return services;
        }
    }
}
