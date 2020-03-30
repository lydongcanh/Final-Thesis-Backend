using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using FinalThesisBackend.Core.Entities;

namespace FinalThesisBackend.Infrastructure.Repositories
{
    public class ProductCollectionRepository : DataAsyncRepository<ProductCollection>
    {
        public ProductCollectionRepository(DataContext dataContext) : base(dataContext) { }

        protected override async Task<IEnumerable<ProductCollection>> GetIncludedEntities()
        {
            return await Entities
                .Include(pc => pc.Details)
                    .ThenInclude(d => d.Product)
                .ToListAsync();
        }
    }
}
