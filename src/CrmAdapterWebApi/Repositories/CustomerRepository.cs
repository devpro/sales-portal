namespace Devpro.SalesPortal.CrmAdapterWebApi.Repositories
{
    public class CustomerRepository : CrudRepositoryBase<CustomerDto>
    {
        public CustomerRepository(ILogger<CustomerRepository> logger, HttpClient client)
            : base(logger, client)
        {
        }

        protected override string ResourceName => "customers";
    }
}
