using Microsoft.AspNetCore.Mvc;

namespace Devpro.SalesPortal.CrmAdapterWebApi.Controllers
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
