using Devpro.SalesPortal.CrmDataWebApi.Entities;
using Devpro.SalesPortal.CrmDataWebApi.Repositories;
using Devpro.SalesPortal.SalesDomain.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace Devpro.SalesPortal.CrmDataWebApi.Controllers
{
    [ApiController]
    [Route("opportunities")]
    public class OpportunityController : CrudControllerBase<OpportunityDto, Opportunity>
    {
        public OpportunityController(ILogger<OpportunityController> logger, ICrudRepository<OpportunityDto, Opportunity> repository)
            : base(logger, repository)
        {
        }
    }
}
