using Devpro.SalesPortal.CrmAdapterWebApi.Repositories;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace Devpro.SalesPortal.CrmAdapterWebApi.DependencyInjection
{
    internal static class ServiceCollectionExtensions
    {
        internal static IServiceCollection AddInfrastructure(this IServiceCollection services, ApplicationConfiguration configuration)
        {
            // recommended: https://learn.microsoft.com/en-us/dotnet/fundamentals/networking/http/httpclient-guidelines#recommended-use
            services.AddSingleton(serviceProvider => new HttpClient
            {
                BaseAddress = new Uri(configuration.CrmDataWebApiUrl)
            });
            services.TryAddScoped<ICrudRepository<CustomerDto>, CustomerRepository>();
            services.TryAddScoped<ICrudRepository<OpportunityDto>, OpportunityRepository>();

            return services;
        }
    }
}
