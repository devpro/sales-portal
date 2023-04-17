using Microsoft.AspNetCore.Mvc;

namespace Devpro.SalesPortal.CrmAdapterWebApi.Controllers
{
    [ApiController]
    [Route("opportunities")]
    public class OpportunityController : CrudControllerBase<OpportunityDto>
    {
        public OpportunityController(ILogger<OpportunityController> logger, ICrudRepository<OpportunityDto> repository)
            : base(logger, repository)
        {
        }
    }
}
