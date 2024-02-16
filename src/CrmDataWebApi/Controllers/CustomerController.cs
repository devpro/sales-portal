using Devpro.SalesPortal.SalesDomain.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace Devpro.SalesPortal.CrmDataWebApi.Controllers
{
    [ApiController]
    [Route("customers")]
    public class CustomerController(ILogger<CustomerController> logger, ICrudRepository<CustomerDto> repository) : CrudControllerBase<CustomerDto>(logger, repository)
    {
    }
}
