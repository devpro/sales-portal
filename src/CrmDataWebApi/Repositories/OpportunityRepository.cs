using AutoMapper;
using Devpro.Common.MongoDb;
using Devpro.SalesPortal.CrmDataWebApi.Entities;
using Devpro.SalesPortal.SalesDomain.Dtos;

namespace Devpro.SalesPortal.CrmDataWebApi.Repositories
{
    public class OpportunityRepository : CrudRepositoryBase<OpportunityDto, Opportunity>
    {
        public OpportunityRepository(IMongoClientFactory mongoClientFactory, ILogger<OpportunityRepository> logger, MongoDbConfiguration configuration, IMapper mapper)
            : base(mongoClientFactory, logger, configuration, mapper)
        {
        }

        protected override string CollectionName => "sales_opportunity";
    }
}
