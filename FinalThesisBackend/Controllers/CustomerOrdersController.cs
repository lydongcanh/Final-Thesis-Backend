using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using FinalThesisBackend.Core.Entities;
using FinalThesisBackend.Core.Interfaces;

namespace FinalThesisBackend.Controllers
{
    [Route("api/[controller]")]
    public class CustomerOrdersController : BaseController<CustomerOrder>
    {
        public CustomerOrdersController(IAsyncRepository<CustomerOrder> repository) : base(repository) { }

        [HttpGet]
        public async Task<IActionResult> Get(
            [FromQuery]string orderState = null,
            [FromQuery]string customerId = null,
            [FromQuery]DateTime? fromDate = null,
            [FromQuery]DateTime? toDate = null)
        {
            if (orderState == null && customerId == null && fromDate == null && toDate == null)
                return Ok(await Repository.SelectAllAsync());

            return Ok(await Repository.SelectAsync(co =>
            {
                return (orderState == null || co.OrderState == orderState) &&
                       (customerId == null || co.CustomerId == customerId) &&
                       (fromDate == null || co.CreationDate.Date.CompareTo(fromDate.Value.Date) >= 0) &&
                       (toDate == null || co.CreationDate.Date.CompareTo(toDate.Value.Date) <= 0);
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
