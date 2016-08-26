using ContactSearch.DataLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace ContactSearch.DataLayer
{
    /// <summary>
    /// The ContactRepository class.
    /// </summary>
    /// <typeparam name="TEntity">The type of the entity.</typeparam>
    /// <typeparam name="TIdentifier">The type of the identifier.</typeparam>
    /// <seealso cref="ContactSearch.DataLayer.IRepository{TEntity, TIdentifier}" />
    class ContactRepository<TEntity, TIdentifier> : IRepository<TEntity, TIdentifier>, IDisposable where TEntity : class
    {
        #region Fields

        /// <summary>
        /// The database context.
        /// </summary>
        private DbContext db;

        /// <summary>
        /// The db set of database context.
        /// </summary>
        private DbSet<TEntity> dbSet;

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="ContactRepository{TEntity, TIdentifier}"/> class.
        /// </summary>
        /// <param name="dbContext">The database context.</param>
        public ContactRepository(DbContext dbContext)
        {
            db = dbContext;
            dbSet = db.Set<TEntity>();
        }

        #endregion Constructors

        #region Methods

        #region public

        /// <summary>
        /// Gets all.
        /// </summary>
        /// <returns>All entities in the repository.</returns>
        public IEnumerable<TEntity> GetAll()
        {
            return dbSet.ToList();
        }

        /// <summary>
        /// Gets the entity by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>The entity.</returns>
        public TEntity GetById(TIdentifier id)
        {
            return dbSet.Find(id);
        }

        /// <summary>
        /// Inserts the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        public void Insert(TEntity entity)
        {
            dbSet.Add(entity);
        }

        /// <summary>
        /// Updates the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        public void Update(TEntity entity)
        {
            db.Entry(entity).State = EntityState.Modified;
        }

        /// <summary>
        /// Deletes the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        public void Delete(TIdentifier id)
        {
            var obj = dbSet.Find(id);
            dbSet.Remove(obj);
        }

        /// <summary>
        /// Saves the changes in repository to database.
        /// </summary>
        public void SaveChanges()
        {
            db.SaveChanges();
        }

        /// <summary>
        /// Repositories the changed.
        /// </summary>
        /// <param name="args">The <see cref="T:ContactSearch.DataLayer.RepositoryChangeEventArgs" /> instance containing the event data.</param>
        /// <returns></returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public EventHandler RepositoryChanged(RepositoryChangeEventArgs args)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Repositories the changing.
        /// </summary>
        /// <param name="args">The <see cref="T:ContactSearch.DataLayer.RepositoryChangeEventArgs" /> instance containing the event data.</param>
        /// <returns></returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public EventHandler RepositoryChanging(RepositoryChangeEventArgs args)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
        }

        #endregion public

        #region Protected

        /// <summary>
        /// Releases unmanaged and - optionally - managed resources.
        /// </summary>
        /// <param name="disposing"><c>true</c> to release both managed and unmanaged resources; <c>false</c> to release only unmanaged resources.</param>
        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (this.db != null)
                {
                    this.db.Dispose();
                    this.db = null;
                }
            }
        }

        #endregion Protected

        #endregion Methods
    }
}
