using Devpro.SalesPortal.CrmDataWebApi.Entities;
using Devpro.SalesPortal.CrmDataWebApi.Repositories;
using Devpro.SalesPortal.SalesDomain.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace Devpro.SalesPortal.CrmDataWebApi.Controllers
{
    [ApiController]
    [Route("customers")]
    public class CustomerController : CrudControllerBase<CustomerDto, Customer>
    {
        public CustomerController(ILogger<CustomerController> logger, ICrudRepository<CustomerDto, Customer> repository)
            : base(logger, repository)
        {
        }
    }
}
