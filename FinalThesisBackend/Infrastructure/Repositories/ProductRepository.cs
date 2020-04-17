using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using FinalThesisBackend.Core.Entities;

namespace FinalThesisBackend.Infrastructure.Repositories
{
    public class ProductRepository : DataAsyncRepository<Product>
    {
        public ProductRepository(DataContext dataContext) : base(dataContext) { }

        protected override async Task<IEnumerable<Product>> GetIncludedEntities()
        {
            return await Entities.Include(p => p.Category).ToListAsync();
        }
    }
}
