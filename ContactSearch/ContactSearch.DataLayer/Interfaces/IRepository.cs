using ContactSearch.DataLayer.Specifications;
using System;
using System.Collections.Generic;

namespace ContactSearch.DataLayer.Interfaces
{
    /// <summary>
    /// The IRepository generic interface.
    /// All repository classes should implement this interface.
    /// </summary>
    /// <typeparam name="TEntity">The type of the entity.</typeparam>
    /// <typeparam name="TIdentifier">The type of the identifier.</typeparam>
    public interface IRepository<TEntity, TIdentifier> where TEntity : class
    {
        #region Methods

        /// <summary>
        /// Gets all.
        /// </summary>
        /// <returns>All entities in the repository.</returns>
        IEnumerable<TEntity> GetAll();

        /// <summary>
        /// Gets the entity by identifier.
        /// </summary>
        /// <param name="Id">The identifier.</param>
        /// <returns>The entity.</returns>
        TEntity GetById(TIdentifier Id);

        /// <summary>
        /// Gets the by specification.
        /// </summary>
        /// <param name="spec">The spec.</param>
        /// <returns>The entities.</returns>
        IEnumerable<TEntity> GetBySpecification(EntitySpecification<TEntity> spec);

        /// <summary>
        /// Inserts the specified entity.
        /// </summary>
        /// <param name="obj">The entity.</param>
        void Insert(TEntity entity);

        /// <summary>
        /// Updates the specified entity.
        /// </summary>
        /// <param name="obj">The entity.</param>
        void Update(TEntity entity);

        /// <summary>
        /// Deletes the entity specified by the identifier.
        /// </summary>
        /// <param name="Id">The identifier.</param>
        void Delete(TIdentifier Id);

        /// <summary>
        /// Saves the changes in repository to database.
        /// </summary>
        void SaveChanges();

        #endregion

        #region Event Handlers

        /// <summary>
        /// Repositories the changed.
        /// </summary>
        /// <param name="args">The <see cref="RepositoryChangeEventArgs"/> instance containing the event data.</param>
        /// <returns></returns>
        EventHandler RepositoryChanged(RepositoryChangeEventArgs args);

        /// <summary>
        /// Repositories the changing.
        /// </summary>
        /// <param name="args">The <see cref="RepositoryChangeEventArgs"/> instance containing the event data.</param>
        /// <returns></returns>
        EventHandler RepositoryChanging(RepositoryChangeEventArgs args);

        #endregion
    }
}
