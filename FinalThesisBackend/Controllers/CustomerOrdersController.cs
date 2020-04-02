using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using FinalThesisBackend.Core.Entities;
using FinalThesisBackend.Core.Interfaces;

namespace FinalThesisBackend.Controllers
{
    public class CustomerOrdersController : BaseController<CustomerOrder>
    {
        public CustomerOrdersController(IAsyncRepository<CustomerOrder> repository) : base(repository) { }

        [HttpGet]
        public async Task<IActionResult> Get(
            [FromQuery]string orderState = null,
            [FromQuery]string customerId = null)
        {
            if (orderState == null && customerId == null)
                return Ok(await Repository.SelectAllAsync());

            return Ok(await Repository.SelectAsync(co =>
            {
                return (orderState == null || co.OrderState == orderState) &&
                       (customerId == null || co.CustomerId == customerId);
            }));
        }

        [HttpPost]
        public override async Task<IActionResult> Post([FromBody]CustomerOrder order)
        {
            order.CreationDate = DateTime.Now;
            return await base.Post(order);
        }
    }
}
