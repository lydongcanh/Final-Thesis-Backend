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
    public class EmployeesController : BaseController<Employee>
    {
        public EmployeesController(IAsyncRepository<Employee> repository) : base(repository) { }

        /// <summary>
        /// GET: api/employees
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> Get(
            [FromQuery]string containsName = null,
            [FromQuery]string containsEmail = null,
            [FromQuery]string jobTitle = null,
            //[FromQuery]string address = null,
            [FromQuery]string containsPhoneNumber = null,
            [FromQuery]string gender = null,
            [FromQuery]DateTime? birthdate = null)
        {
            if (containsName == null && containsEmail == null && jobTitle == null &&
                /** address == null && **/ containsPhoneNumber == null && gender == null && birthdate == null)
                return Ok(await Repository.SelectAllAsync());

            return Ok(await Repository.SelectAsync(e =>
            {
                return (containsName == null || e.Name.Contains(containsName)) &&
                       (containsEmail == null || e.Email.Contains(containsEmail)) &&
                       (jobTitle == null || e.JobTitle == jobTitle) &&
                       //(address == null || e.Address.Contains(address)) &&
                       (containsPhoneNumber == null || e.PhoneNumber.Contains(containsPhoneNumber)) &&
                       (gender == null || e.Gender == gender) &&
                       (!birthdate.HasValue || e.Birthdate.Date == birthdate.Value.Date);
            }));
        }
    }
}
