using System;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using FinalThesisBackend.Core.Entities;

namespace FinalThesisBackend.Infrastructure.Repositories
{
    public class AccountRepository : DataAsyncRepository<Account>
    {
        public AccountRepository(DataContext dataContext) : base(dataContext) { }

        protected override async Task<IEnumerable<Account>> GetIncludedEntities()
        {
            return await Entities
                .Include(a => a.Customer)
                    //.ThenInclude(c => c.CartItems)
                    //    .ThenInclude(ci => ci.ProductDetails)
                    //        .ThenInclude(pd => pd.Product)
                .Include(a => a.Employee)
                .ToListAsync();
        }
    }
}
