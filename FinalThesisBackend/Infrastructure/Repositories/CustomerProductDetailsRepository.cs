using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using FinalThesisBackend.Core.Entities;

namespace FinalThesisBackend.Infrastructure.Repositories
{
    public class CustomerProductDetailsRepository : DataAsyncRepository<CustomerProductDetails>
    {
        public CustomerProductDetailsRepository(DataContext dataContext) : base(dataContext) { }

        protected override async Task<IEnumerable<CustomerProductDetails>> GetIncludedEntities()
        {
            return await Entities.Include(cpd => cpd.Product).ToListAsync();
        }
    }
}
