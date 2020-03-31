using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using FinalThesisBackend.Core.Entities;
using FinalThesisBackend.Core.Interfaces;

namespace FinalThesisBackend.Controllers
{
    [Route("api/[controller]")]
    public class CustomerCartItemsController : BaseController<CustomerCartItem>
    {
        public CustomerCartItemsController(IAsyncRepository<CustomerCartItem> repository) : base(repository) { }

        [HttpGet]
        public async Task<IActionResult> Get(
                [FromQuery]string customerId = null,
                [FromQuery]string productDetailsId = null)
        {
            if (customerId == null && productDetailsId == null)
                return Ok(await Repository.SelectAllAsync());

            return Ok(await Repository.SelectAsync(cci =>
            {
                return (customerId == null || cci.CustomerId == customerId) &&
                       (productDetailsId == null || cci.ProductDetailsId == productDetailsId);
            }));
        }

        [HttpPost]
        public override async Task<IActionResult> Post([FromBody]CustomerCartItem cartItem)
        {
            cartItem.AddedDate = DateTime.Now;
            return await base.Post(cartItem);
        }
    }
}
