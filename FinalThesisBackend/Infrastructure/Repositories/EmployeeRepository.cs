using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using FinalThesisBackend.Core.Entities;
 
namespace FinalThesisBackend.Infrastructure.Repositories
{
    public class EmployeeRepository : DataAsyncRepository<Employee>
    {
        public EmployeeRepository(DataContext dataContext) : base(dataContext) { }

        protected override async Task<IEnumerable<Employee>> GetIncludedEntities()
        {
            return await Entities
                .Include(e => e.Account)
                .ToListAsync();
        }
    }
}
