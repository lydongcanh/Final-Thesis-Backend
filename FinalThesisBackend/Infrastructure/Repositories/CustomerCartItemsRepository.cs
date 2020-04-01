using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using FinalThesisBackend.Core.Entities;

namespace FinalThesisBackend.Infrastructure.Repositories
{
    public class CustomerCartItemsRepository : DataAsyncRepository<CustomerCartItem>
    {
        public CustomerCartItemsRepository(DataContext dataContext) : base(dataContext) { }

        protected override async Task<IEnumerable<CustomerCartItem>> GetIncludedEntities()
        {
            return await Entities
                .Include(cci => cci.ProductDetails)
                    .ThenInclude(pd => pd.Product)
                .ToListAsync();
        }
    }
}
