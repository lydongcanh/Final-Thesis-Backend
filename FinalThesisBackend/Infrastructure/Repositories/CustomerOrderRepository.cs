using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using FinalThesisBackend.Core.Entities;

namespace FinalThesisBackend.Infrastructure.Repositories
{
    public class CustomerOrderRepository : DataAsyncRepository<CustomerOrder>
    {
        public CustomerOrderRepository(DataContext dataContext) : base(dataContext) { }

        protected override async Task<IEnumerable<CustomerOrder>> GetIncludedEntities()
        {
            return await Entities.Include(co => co.OrderDetails).ToListAsync();
        }
    }
}
