using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FinalThesisBackend.Core.Entities;
using FinalThesisBackend.Core.Interfaces;

namespace FinalThesisBackend.Controllers
{
    [Route("api/[controller]")]
    public class CategoriesController : Controller
    {
        private readonly IAsyncRepository<Category> Repository;

        public CategoriesController(IAsyncRepository<Category> repository)
        {
            Repository = repository;
        }

        // GET: api/categories
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await Repository.SelectAllAsync());
        }

        // GET api/categories/id
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(string id)
        {
            return Ok(await Repository.SelectByIdAsync(id));
        }

        // POST api/categories
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]Category category)
        {
            return Ok(await Repository.AddAsync(category));
        }

        // PUT api/categories/id
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(string id, [FromBody]Category category)
        {
            return Ok(await Repository.UpdateAsync(category));
        }

        // DELETE api/categories/id
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            var category = await Repository.SelectByIdAsync(id);
            if (category == default(Category))
                return NotFound();

            return Ok(await Repository.DeleteAsync(category));
        }
    }
}
