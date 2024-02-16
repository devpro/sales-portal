using Devpro.SalesPortal.CrmDataWebApi.Entities;
using Devpro.SalesPortal.SalesDomain.Dtos;

namespace Devpro.SalesPortal.CrmDataWebApi.Repositories
{
    public class OpportunityRepository(IMongoClientFactory mongoClientFactory, ILogger<OpportunityRepository> logger, MongoDbConfiguration configuration, IMapper mapper)
        : CrudRepositoryBase<OpportunityDto, Opportunity>(mongoClientFactory, logger, configuration, mapper)
    {
        protected override string CollectionName => "sales_opportunity";
    }
}
