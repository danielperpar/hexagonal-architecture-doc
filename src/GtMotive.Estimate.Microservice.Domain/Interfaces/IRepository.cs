using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GtMotive.Estimate.Microservice.Domain.Interfaces
{
    /// <summary>
    /// Repository interface.
    /// </summary>
    /// <typeparam name="TEntity">Type of the entities.</typeparam>
    public interface IRepository<TEntity> : IDisposable
    where TEntity : class
    {
        /// <summary>
        /// Add entitiy to the repository.
        /// </summary>
        /// <param name="entity">Entity to be added to the repository.</param>
        void Add(TEntity entity);

        /// <summary>
        /// Get entity from the repository.
        /// </summary>
        /// <param name="id">Entity id.</param>
        /// <returns>Entity.</returns>
        Task<TEntity> GetById(Guid id);

        /// <summary>
        /// Get all entities from the repository.
        /// </summary>
        /// <returns>Entities.</returns>
        Task<IEnumerable<TEntity>> GetAll();

        /// <summary>
        /// Update an entity in the repository.
        /// </summary>
        /// <param name="entity">Entity to be updated.</param>
        void Update(TEntity entity);

        /// <summary>
        /// Removes and entity from the repository.
        /// </summary>
        /// <param name="id">Entity id.</param>
        void Remove(Guid id);
    }
}
