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
    public class EmployeesController : Controller
    {
        private readonly IAsyncRepository<Employee> Employees;

        public EmployeesController(IAsyncRepository<Employee> employees)
        {
            Employees = employees;
        }

        // GET: api/employees
        [HttpGet]
        public async Task<IActionResult> Get(
            [FromQuery]string firstName = null,
            [FromQuery]string lastName = null,
            [FromQuery]DateTime? birthdate = null,
            [FromQuery]DateTime? hiredate = null,
            [FromQuery]string address = null,
            [FromQuery]string phoneNumber = null)
        {
            if (firstName == null && lastName == null && birthdate == null &&
                hiredate == null && address == null && phoneNumber == null)
                return Ok(await Employees.SelectAllAsync());

            return Ok(await Employees.SelectAsync(e =>
            {
                return (firstName == null || e.FirstName.Contains(firstName)) &&
                       (lastName == null || e.LastName.Contains(lastName)) &&
                       (!birthdate.HasValue || e.Birthdate.Date == birthdate.Value.Date) &&
                       (!hiredate.HasValue || e.Hiredate.Date == hiredate.Value.Date) &&
                       (address == null || e.Address.Contains(address)) &&
                       (phoneNumber == null || e.PhoneNumber.Contains(phoneNumber));
            }));
        }

        // GET api/employees/id
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(string id)
        {
            return Ok(await Employees.SelectByIdAsync(id));
        }

        // POST api/employees
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]Employee employee)
        {
            return Ok(await Employees.AddAsync(employee));
        }

        // PUT api/employees/id
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(string id, [FromBody]Employee employee)
        {
            return Ok(await Employees.UpdateAsync(employee));
        }

        // DELETE api/employees/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            var employee = await Employees.SelectByIdAsync(id);
            if (employee == default(Employee))
                return NotFound(id);

            return Ok(await Employees.DeleteAsync(employee));
        }
    }
}
