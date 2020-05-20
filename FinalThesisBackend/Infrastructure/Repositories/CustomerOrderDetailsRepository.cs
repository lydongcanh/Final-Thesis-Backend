using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using FinalThesisBackend.Core.Entities;

namespace FinalThesisBackend.Infrastructure.Repositories
{
    public class CustomerOrderDetailsRepository : DataAsyncRepository<CustomerOrderDetails>
    {
        public CustomerOrderDetailsRepository(DataContext dataContext) : base(dataContext) { }

        protected override async Task<IEnumerable<CustomerOrderDetails>> GetIncludedEntities()
        {
            return await Entities
                .Include(co => co.ProductDetails)
                    .ThenInclude(pd => pd.Product)
                .ToListAsync();
        }
    }
}
