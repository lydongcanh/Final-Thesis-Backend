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
    public class ProductCollectionDetaisController : BaseController<ProductCollectionDetails>
    {
        public ProductCollectionDetaisController(IAsyncRepository<ProductCollectionDetails> repository)
            : base(repository) { }

        [HttpGet]
        public async Task<IActionResult> Get(
            [FromQuery]bool? showOnMainPage = null,
            [FromQuery]string productId = null,
            [FromQuery]string collectionId = null)
        {
            if (showOnMainPage == null && productId == null && collectionId == null)
                return Ok(await Repository.SelectAllAsync());

            return Ok(await Repository.SelectAsync(pcd =>
            {
                return (showOnMainPage == null || pcd.ShowOnMainPage == showOnMainPage) &&
                       (productId == null || pcd.ProductId == productId) &&
                       (collectionId == null || pcd.ProductCollectionId == collectionId);
            }));
        }
    }
}
