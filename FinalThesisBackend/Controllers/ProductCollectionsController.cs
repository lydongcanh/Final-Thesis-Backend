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
    public class ProductCollectionsController : BaseController<ProductCollection>
    {
        public ProductCollectionsController(IAsyncRepository<ProductCollection> repository) : base(repository) { }

        [HttpGet]
        public async Task<IActionResult> Get(
            [FromQuery]bool? showOnMainPage = null,
            [FromQuery]string containsName = null)
        {
            if (showOnMainPage == null && containsName == null)
                return Ok(await Repository.SelectAllAsync());

            return Ok(await Repository.SelectAsync(pc =>
            {
                return (showOnMainPage == null || pc.ShowOnMainPage == showOnMainPage) &&
                       (containsName == null || pc.Name.Contains(containsName));
            }));
        }
    }
}
