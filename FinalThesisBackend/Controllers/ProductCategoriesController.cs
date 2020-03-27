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
    public class ProductCategoriesController : BaseController<ProductCategory>
    {
        public ProductCategoriesController(IAsyncRepository<ProductCategory> repository) : base(repository) { }

        /// <summary>
        /// GET: api/categories
        /// </summary>
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
    }
}
