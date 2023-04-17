using Devpro.SalesPortal.SalesDomain.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace Devpro.SalesPortal.CrmDataWebApi.Controllers
{
    [ApiController]
    [Route("customers")]
    public class CustomerController : CrudControllerBase<CustomerDto>
    {
        public CustomerController(ILogger<CustomerController> logger, ICrudRepository<CustomerDto> repository)
            : base(logger, repository)
        {
        }
    }
}
