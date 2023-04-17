namespace Devpro.SalesPortal.CrmAdapterWebApi.Repositories
{
    public class OpportunityRepository : CrudRepositoryBase<OpportunityDto>
    {
        public OpportunityRepository(ILogger<OpportunityRepository> logger, HttpClient client)
            : base(logger, client)
        {
        }

        protected override string ResourceName => "opportunities";
    }
}
