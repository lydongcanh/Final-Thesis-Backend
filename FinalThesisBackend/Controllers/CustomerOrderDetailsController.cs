using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using FinalThesisBackend.Core.Entities;
using FinalThesisBackend.Core.Interfaces;

namespace FinalThesisBackend.Controllers
{
    public class CustomerOrderDetailsController : BaseController<CustomerOrderDetails>
    {
        public CustomerOrderDetailsController(IAsyncRepository<CustomerOrderDetails> repository) : base(repository) { }

        [HttpGet]
        public async Task<IActionResult> Get(
            [FromQuery]string productDetailsId = null,
            [FromQuery]string customerOrderId = null)
        {
            if (productDetailsId == null && customerOrderId == null)
                return Ok(await Repository.SelectAllAsync());

            return Ok(await Repository.SelectAsync(cod =>
            {
                return (productDetailsId == null || cod.ProductDetailsId == productDetailsId) &&
                       (customerOrderId == null || cod.CustomerOrderId == customerOrderId);
            }));
        }
    }
}
