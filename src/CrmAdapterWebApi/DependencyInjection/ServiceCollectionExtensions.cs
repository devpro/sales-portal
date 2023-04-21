using Devpro.SalesPortal.CrmAdapterWebApi.Repositories;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace Devpro.SalesPortal.CrmAdapterWebApi.DependencyInjection
{
    internal static class ServiceCollectionExtensions
    {
        internal static IServiceCollection AddInfrastructure(this IServiceCollection services, ApplicationConfiguration configuration)
        {
            // recommended: https://learn.microsoft.com/en-us/dotnet/fundamentals/networking/http/httpclient-guidelines#recommended-use
            services.AddSingleton(serviceProvider =>
            {
                if (configuration.IsCertificateValidationSkipped)
                {
                    var handler = new HttpClientHandler
                    {
                        // skip certificate validation in HTTPS calls https://learn.microsoft.com/en-us/dotnet/api/system.net.http.httpclienthandler.dangerousacceptanyservercertificatevalidator
                        ServerCertificateCustomValidationCallback = HttpClientHandler.DangerousAcceptAnyServerCertificateValidator
                    };
                    return new HttpClient(handler)
                    {
                        BaseAddress = new Uri(configuration.CrmDataWebApiUrl)
                    };
                }

                return new HttpClient()
                {
                    BaseAddress = new Uri(configuration.CrmDataWebApiUrl)
                };
            });

            services.TryAddScoped<ICrudRepository<CustomerDto>, CustomerRepository>();
            services.TryAddScoped<ICrudRepository<OpportunityDto>, OpportunityRepository>();

            return services;
        }
    }
}
