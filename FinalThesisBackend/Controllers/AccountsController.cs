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
    public class AccountsController : Controller
    {
        private readonly IAsyncRepository<Account> Accounts;

        public AccountsController (IAsyncRepository<Account> accounts)
        {
            Accounts = accounts;
        }

        // GET: api/accounts
        [HttpGet]
        public async Task<IActionResult> Get(
            [FromQuery]string username,
            [FromQuery]string password,
            [FromQuery]string type,
            [FromQuery]bool? isActive)
        {
            if (username == null && type == null && isActive == null)
                return Ok(await Accounts.SelectAllAsync());

            return Ok(await Accounts.SelectAsync(a =>
            {
                return (username == null || a.Username == username) &&
                       (password == null || a.Password == password) &&
                       (type == null || a.AccountType == type) &&
                       (isActive == null || a.IsActive == isActive);
            }));
        }

        // GET api/accounts/id
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(string id)
        {
            return Ok(await Accounts.SelectByIdAsync(id));
        }

        // POST api/accounts
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]Account account)
        {
            return Ok(await Accounts.AddAsync(account));
        }

        // PUT api/accounts/id
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(string id, [FromBody]Account account)
        {
            return Ok(await Accounts.UpdateAsync(account));
        }

        // DELETE api/accounts/id
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            var account = await Accounts.SelectByIdAsync(id);
            if (account == null)
                return NotFound(id);

            return Ok(await Accounts.DeleteAsync(account));
        }
    }
}
