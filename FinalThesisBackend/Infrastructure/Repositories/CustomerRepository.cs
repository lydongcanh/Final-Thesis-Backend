using System;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using FinalThesisBackend.Core.Entities;

namespace FinalThesisBackend.Infrastructure.Repositories
{
    public class CustomerRepository : DataAsyncRepository<Customer>
    {
        public CustomerRepository(DataContext dataContext) : base(dataContext) { }

        protected override async Task<IEnumerable<Customer>> GetIncludedEntities()
        {
            return await Entities
                //.Include(c => c.Orders)
                //.Include(c => c.Account)
                .ToListAsync();
        }
    }
}
