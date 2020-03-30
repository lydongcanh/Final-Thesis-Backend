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
        protected readonly DataContext DataContext;

        protected virtual DbSet<T> Entities { get => DataContext.Set<T>(); }

        public DataAsyncRepository(DataContext dataContext)
        {
            DataContext = dataContext;
        }

        /// <summary>
        /// Override this method if the entity has some property need to be included.
        /// </summary>
        protected virtual async Task<IEnumerable<T>> GetIncludedEntities()
        {
            return await Entities.ToListAsync();
        }

        public virtual async Task<T> SelectByIdAsync (string id)
        {
            if (id == null)
                throw new ArgumentNullException();

            var list = await GetIncludedEntities();
            return list.FirstOrDefault(e => e.Id == id);
        }

        public virtual async Task<IEnumerable<T>> SelectAllAsync()
        {
            return await GetIncludedEntities();
        }

        public virtual async Task<IEnumerable<T>> SelectAsync(Func<T, bool> predicate)
        {
            var list = await GetIncludedEntities();
            return list.Where(predicate);
        }

        public virtual async Task<int> CountAsync()
        {
            return await Entities.CountAsync();
        }

        public virtual async Task<T> AddAsync(T entity)
        {
            var result = Entities.Add(entity);
            await DataContext.SaveChangesAsync();

            return result.Entity;
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
