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
    public class ProductDetailsController : BaseController<ProductDetails>
    {
        public ProductDetailsController (IAsyncRepository<ProductDetails> repository) : base (repository) { }

        [HttpGet]
        public async Task<IActionResult> Get(
            [FromQuery]string productId = null,
            [FromQuery]string size = null,
            [FromQuery]string color = null,
            [FromQuery]int? unitInStock = null
            )
        {
            if (productId == null && size == null && color == null && unitInStock == null)
                return Ok(await Repository.SelectAllAsync());

            return Ok(await Repository.SelectAsync(pd =>
            {
                return (productId == null || pd.ProductId == productId) &&
                       (size == null || pd.Size == size) &&
                       (color == null || pd.Color == color) &&
                       (unitInStock == null || pd.UnitsInStock == unitInStock);
            }));
        }
    }
}
