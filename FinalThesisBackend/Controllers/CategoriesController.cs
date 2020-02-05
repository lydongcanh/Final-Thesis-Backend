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
    public class CategoriesController : ControllerBase
    {
        private readonly IAsyncRepository<Category> Repository;

        public CategoriesController(IAsyncRepository<Category> repository)
        {
            Repository = repository;
        }

        // GET: api/categories
        [HttpGet]
        public async Task<IActionResult> Get(
            [FromQuery]string name = null,
            [FromQuery]bool? isRoot = null,
            [FromQuery]bool? isLeaf = null)
        {
            if (name == null && isRoot == null && isLeaf == null)
                return Ok(await Repository.SelectAllAsync());

            return Ok(await Repository.SelectAsync(category =>
            {
                return (name == null || category.Name == name) &&
                       (isRoot == null || category.IsRoot == isRoot.Value) &&
                       (isLeaf == null || category.IsLeaf == isLeaf.Value);
            }));
        }

        // GET api/categories/id
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(string id)
        {
            var category = await Repository.SelectByIdAsync(id);

            if (category == default(Category))
                return NotFound();

            return Ok(category);
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
