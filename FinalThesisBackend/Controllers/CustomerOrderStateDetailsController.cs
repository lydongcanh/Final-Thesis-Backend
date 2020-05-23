using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using FinalThesisBackend.Core.Entities;
using FinalThesisBackend.Core.Interfaces;

namespace FinalThesisBackend.Controllers
{
    [Route("api/[controller]")]
    public class CustomerOrderStateDetailsController : BaseController<CustomerOrderStateDetails>
    {
        public CustomerOrderStateDetailsController(IAsyncRepository<CustomerOrderStateDetails> repository) : base(repository) { }

        [HttpGet]
        public async Task<IActionResult> Get(
            [FromQuery]string customerOrderId = null,
            [FromQuery]string employeeId = null)
        {
            if (customerOrderId == null && employeeId == null)
                return Ok(await Repository.SelectAllAsync());

            return Ok(await Repository.SelectAsync(cod =>
            {
                return (customerOrderId == null || cod.CustomerOrderId == customerOrderId) &&
                       (employeeId == null || cod.EmployeeId == employeeId);
            }));
        }

        [HttpPost]
        public override async Task<IActionResult> Post([FromBody]CustomerOrderStateDetails details)
        {
            details.CreationDate = DateTime.Now;
            return await base.Post(details);
        }
    }
}
