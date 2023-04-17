using AutoMapper;
using Devpro.SalesPortal.CrmDataWebApi.Entities;
using Devpro.SalesPortal.SalesDomain.Dtos;

namespace Devpro.SalesPortal.CrmDataWebApi.Repositories
{
    public class CustomerRepository : CrudRepositoryBase<CustomerDto, Customer>
    {
        public CustomerRepository(IMongoClientFactory mongoClientFactory, ILogger<CustomerRepository> logger, MongoDbConfiguration configuration, IMapper mapper)
            : base(mongoClientFactory, logger, configuration, mapper)
        {
        }

        protected override string CollectionName => "sales_customer";
    }
}
