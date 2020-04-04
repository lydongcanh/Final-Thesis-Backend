using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using FinalThesisBackend.Core.Entities;
using FinalThesisBackend.Core.Interfaces;

namespace FinalThesisBackend.Controllers
{
    [Route("api/[controller]")]
    public class CustomerProductDetailsController : BaseController<CustomerProductDetails>
    {
        public CustomerProductDetailsController(IAsyncRepository<CustomerProductDetails> repository)
            : base(repository) { }

        [HttpGet]
        public async Task<IActionResult> Get(
            [FromQuery]string customerId = null,
            [FromQuery]string productId = null)
        {
            if (customerId == null && productId == null)
                return Ok(await Repository.SelectAllAsync());

            return Ok(await Repository.SelectAsync(cpd =>
            {
                return (customerId == null || cpd.CustomerId == customerId) &&
                       (productId == null || cpd.ProductId == productId);
            }));
        }
    }
}
