﻿using Devpro.SalesPortal.CrmDataWebApi.Repositories;
using Devpro.SalesPortal.SalesDomain.Dtos;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace Devpro.SalesPortal.CrmDataWebApi.DependencyInjection
{
    internal static class ServiceCollectionExtensions
    {
        internal static IServiceCollection AddMapping(this IServiceCollection services)
        {
            // AutoMapper
            var mappingConfig = new MapperConfiguration(x =>
            {
                x.AddProfile(new Mapping.CrmDataMappingProfile());
                x.CreateMap<MongoDB.Bson.ObjectId, string>().ConvertUsing<Mapping.ObjectIdToStringConverter>();
                x.CreateMap<string, MongoDB.Bson.ObjectId>().ConvertUsing<Mapping.StringToObjectIdConverter>();
                x.AllowNullCollections = true;
            });
            var mapper = mappingConfig.CreateMapper();
            mapper.ConfigurationProvider.AssertConfigurationIsValid();
            services.AddSingleton(mapper);

            return services;
        }

        internal static IServiceCollection AddInfrastructure(this IServiceCollection services, MongoDbConfiguration mongoDbConfiguration)
        {
            // MongoDB
            services.AddSingleton(mongoDbConfiguration);
            services.TryAddSingleton<IMongoClientFactory, DefaultMongoClientFactory>();
            services.TryAddScoped<ICrudRepository<CustomerDto>, CustomerRepository>();
            services.TryAddScoped<ICrudRepository<OpportunityDto>, OpportunityRepository>();

            return services;
        }
    }
}
