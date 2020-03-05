using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using FinalThesisBackend.Core.Interfaces;
using FinalThesisBackend.Core.Entities;

namespace FinalThesisBackend.Controllers
{
    [Route("api/[controller]")]
    public class CustomersController : BaseController<Customer>
    {
        public CustomersController(IAsyncRepository<Customer> repository) : base(repository) { }

        /// <summary>
        /// GET: api/customers
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> Get(
            [FromQuery]string containsName = null,
            [FromQuery]string containsEmail = null,
            [FromQuery]string vipLevel = null,
            [FromQuery]string address = null,
            [FromQuery]string containsPhoneNumber = null,
            [FromQuery]string gender = null,
            [FromQuery]DateTime? birthdate = null)
        {
            if (containsName == null && containsEmail == null && vipLevel == null &&
                address == null && containsPhoneNumber == null && gender == null && birthdate == null)
                return Ok(await Repository.SelectAllAsync());

            return Ok(await Repository.SelectAsync(c =>
            {
                return (containsName == null || c.Name.Contains(containsName)) &&
                       (containsEmail == null || c.Email.Contains(containsEmail)) &&
                       (vipLevel == null || c.VipLevel == vipLevel) &&
                       (address == null || c.Address.Contains(address)) &&
                       (containsPhoneNumber == null || c.PhoneNumber.Contains(containsPhoneNumber)) &&
                       (gender == null || c.Gender == gender) &&
                       (!birthdate.HasValue || c.Birthdate.Date == birthdate.Value.Date);
            }));
        }
    }
}
