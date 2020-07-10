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
    public class ProductsController : BaseController<Product>
    {
        public ProductsController(IAsyncRepository<Product> repository) : base(repository) { }

        /// <summary>
        /// GET apis/products.
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> Get(
            [FromQuery]string containsName = null,
            [FromQuery]bool? isSelling = null,
            [FromQuery]string categoryId = null)
        {
            if (containsName == null && isSelling == null && categoryId == null)
                return Ok(await Repository.SelectAllAsync());

            return Ok(await Repository.SelectAsync(p =>
            {
                return (containsName == null || p.Name.ToLower().Contains(containsName.ToLower())) &&
                       (isSelling == null || p.IsSelling == isSelling) &&
                       (categoryId == null || p.CategoryId == categoryId);
            }));
        }

        /// <summary>
        /// POST api/[controller]
        /// </summary>
        [HttpPost]
        public override async Task<IActionResult> Post([FromBody]Product entity)
        {
            entity.CreationDate = DateTime.Now;
            return await base.Post(entity);
        }
    }
}
