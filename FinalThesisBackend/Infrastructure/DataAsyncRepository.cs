using System;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using FinalThesisBackend.Core.Entities;
using FinalThesisBackend.Core.Interfaces;

namespace FinalThesisBackend.Infrastructure
{
    public class DataAsyncRepository<T>: IAsyncRepository<T> where T : BaseEntity
    {
        private readonly DataContext DataContext;

        private DbSet<T> Entities => DataContext.Set<T>();

        public DataAsyncRepository(DataContext dataContext)
        {
            DataContext = dataContext;
        }

        public virtual async Task<T> SelectByIdAsync (string id)
        {
            if (id == null)
                throw new ArgumentNullException();

            return await Entities.FirstOrDefaultAsync(e => e.Id == id);
        }

        public virtual async Task<IEnumerable<T>> SelectAllAsync()
        {
            return await Entities.ToListAsync();
        }

        public virtual async Task<IEnumerable<T>> SelectAsync(Func<T, bool> predicate)
        {
            var all = await Entities.ToListAsync();
            return all.Where(predicate);
        }

        public virtual async Task<int> CountAsync()
        {
            return await Entities.CountAsync();
        }

        public virtual async Task<T> AddAsync(T entity)
        {
            Entities.Add(entity);
            await DataContext.SaveChangesAsync();

            return entity;
        }

        public virtual async Task<bool> UpdateAsync(T entity)
        {
            DataContext.Entry(entity).State = EntityState.Modified;
            return await DataContext.SaveChangesAsync() > 0;
        }

        public virtual async Task<bool> DeleteAsync(T entity)
        {
            Entities.Remove(entity);
            return await DataContext.SaveChangesAsync() > 0;
        }
    }
}
