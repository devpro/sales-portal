using Devpro.SalesPortal.SalesDomain.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace Devpro.SalesPortal.CrmDataWebApi.Controllers
{
    [ApiController]
    [Route("opportunities")]
    public class OpportunityController(ILogger<OpportunityController> logger, ICrudRepository<OpportunityDto> repository) : CrudControllerBase<OpportunityDto>(logger, repository)
    {
    }
}
