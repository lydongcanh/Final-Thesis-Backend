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
    public class AccountsController : BaseController<Account>
    {
        public AccountsController(IAsyncRepository<Account> repository) : base(repository) { }

        /// <summary>
        /// GET: api/accounts
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> Get(
            [FromQuery]string username = null,
            [FromQuery]string password = null,
            [FromQuery]string type = null,
            [FromQuery]bool? isActive = null,
            [FromQuery]string customerId = null,
            [FromQuery]string employeeId = null)
        {
            if (username == null && password == null && type == null && isActive == null &&
                customerId == null && employeeId == null)
                return Ok(await Repository.SelectAllAsync());

            return Ok(await Repository.SelectAsync(a =>
            {
                return (username == null || a.Username == username) &&
                       (password == null || a.Password == password) &&
                       (customerId == null || a.CustomerId == customerId) &&
                       (employeeId == null || a.EmployeeId == employeeId) &&
                       (type == null || a.AccountType == type) &&
                       (isActive == null || a.IsActive == isActive);
            }));
        }
    }
}
