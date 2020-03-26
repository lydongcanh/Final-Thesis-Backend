using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using FinalThesisBackend.Core.Entities;
using FinalThesisBackend.Core.Interfaces;

namespace FinalThesisBackend.Controllers
{
    /// <summary>
    /// Base class for all controllers.
    /// </summary>
    /// <typeparam name="T">Entity type.</typeparam>
    /// TODO: Add specifications to simplify query.
    [Route("api/[controller]")]
    public abstract class BaseController<T> : Controller where T: BaseEntity
    {
        protected readonly IAsyncRepository<T> Repository;

        public BaseController(IAsyncRepository<T> repository)
        {
            Repository = repository;
        }

        /// <summary>
        /// GET api/[controller]
        /// </summary>
        [HttpGet("{id}")]
        public virtual async Task<IActionResult> Get(string id)
        {
            var category = await Repository.SelectByIdAsync(id);

            if (category == default(T))
                return NotFound();

            return Ok(category);
        }

        /// <summary>
        /// POST api/[controller]
        /// </summary>
        [HttpPost]
        public virtual async Task<IActionResult> Post([FromBody]T entity)
        {
            entity.Id = Guid.NewGuid().ToString();
            return Ok(await Repository.AddAsync(entity));
        }

        /// <summary>
        /// PUT api/[controller]/id
        /// </summary>
        [HttpPut("{id}")]
        public virtual async Task<IActionResult> Put(string id, [FromBody]T entity)
        {
            return Ok(await Repository.UpdateAsync(entity));
        }

        /// <summary>
        /// DELETE api/[controller]/id
        /// </summary>
        [HttpDelete("{id}")]
        public virtual async Task<IActionResult> Delete(string id)
        {
            var category = await Repository.SelectByIdAsync(id);
            if (category == default(T))
                return NotFound(id);

            return Ok(await Repository.DeleteAsync(category));
        }
    }
}
