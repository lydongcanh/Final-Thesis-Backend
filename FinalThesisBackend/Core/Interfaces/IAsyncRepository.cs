using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using FinalThesisBackend.Core.Entities;

namespace FinalThesisBackend.Core.Interfaces
{
    public interface IAsyncRepository<T> where T: BaseEntity
    {
        /// <summary>
        /// Select an entity by its id.
        /// </summary>
        /// <param name="id">Id.</param>
        Task<T> SelectByIdAsync(string id);

        /// <summary>
        /// Select all entities.
        /// </summary>
        Task<IEnumerable<T>> SelectAllAsync();

        /// <summary>
        /// Select an entity with filter.
        /// </summary>
        /// <param name="predicate">Filter predicate.</param>
        Task<IEnumerable<T>> SelectAsync(Func<T, bool> predicate);

        /// <summary>
        /// Count number of entities.
        /// </summary>
        Task<int> CountAsync();

        /// <summary>
        /// Add new entity into database.
        /// </summary>
        /// <param name="entity">Entity.</param>
        /// <returns>Added entity.</returns>
        Task<T> AddAsync(T entity);

        /// <summary>
        /// Update an existing entity.
        /// </summary>
        /// <param name="entity">New entity to override.</param>
        /// <returns>Update successfully or not.</returns>
        Task<bool> UpdateAsync(T entity);

        /// <summary>
        /// Delete an existing entity.
        /// </summary>
        /// <param name="entity">Target entity to delete.</param>
        /// <returns>Delete successfully or not.</returns>
        Task<bool> DeleteAsync(T entity);
    }
}
