using Microsoft.AspNetCore.Mvc;

namespace Devpro.SalesPortal.CrmAdapterWebApi.Controllers
{
    [ApiController]
    [Route("customers")]
    public class CustomerController(ILogger<CustomerController> logger, ICrudRepository<CustomerDto> repository) : CrudControllerBase<CustomerDto>(logger, repository)
    {
    }
}
