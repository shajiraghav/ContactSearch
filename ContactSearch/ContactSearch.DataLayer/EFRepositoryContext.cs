using ContactSearch.DataLayer.Interfaces;
using System;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;

namespace ContactSearch.DataLayer
{
    /// <summary>
    /// The generic EFRepositoryContext class.
    /// </summary>
    /// <typeparam name="TEntity">The type of the entity.</typeparam>
    /// <typeparam name="TIdentifier">The type of the identifier.</typeparam>
    /// <seealso cref="ContactSearch.DataLayer.RepositoryContextBase{TEntity, TIdentifier}" />
    public class EFRepositoryContext<TEntity, TIdentifier> : RepositoryContextBase<TEntity, TIdentifier> where TEntity : class
    {
        #region Fields

        /// <summary>
        /// The connection string
        /// </summary>
        private readonly string connectionString;

        /// <summary>
        /// The database context
        /// </summary>
        protected DbContext dbContext;

        #endregion Fields

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="EFRepositoryContext{TEntity, TIdentifier}"/> class.
        /// </summary>
        /// <param name="connectionString">The connection string.</param>
        public EFRepositoryContext(string connectionString)
        {
            this.connectionString = connectionString;
        }

        #endregion Constructors

        #region Methods

        #region Publics

        /// <summary>
        /// Releases unmanaged and - optionally - managed resources.
        /// </summary>
        /// <param name="disposing"><c>true</c> to release both managed and unmanaged resources; <c>false</c> to release only unmanaged resources.</param>
        /// <exception cref="System.NotImplementedException"></exception>
        public override void Dispose(bool disposing)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Gets the repository.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public override IRepository<TEntity, TIdentifier> GetRepository()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Afters the commit.
        /// </summary>
        /// <param name="args">The <see cref="AfterCommitEventArgs"/> instance containing the event data.</param>
        /// <returns></returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public override EventHandler AfterCommit(AfterCommitEventArgs args)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Befores the commit.
        /// </summary>
        /// <param name="args">The <see cref="BeforeRollbackeEventArgs"/> instance containing the event data.</param>
        /// <returns></returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public override EventHandler BeforeCommit(BeforeRollbackeEventArgs args)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Commits this instance.
        /// </summary>
        /// <returns></returns>
        public override int Commit()
        {
            if (dbContext.ChangeTracker.Entries().Any(IsChanged))
            {
                return dbContext.SaveChanges();
            }
            return 0;
        }

        /// <summary>
        /// Rollbacks this instance.
        /// </summary>
        /// <exception cref="System.NotImplementedException"></exception>
        public override void Rollback()
        {
            throw new NotImplementedException();
        }

        #endregion Publics

        #region Privates

        private static bool IsChanged(DbEntityEntry entity)
        {
            return IsStateEqual(entity, EntityState.Added) ||
                   IsStateEqual(entity, EntityState.Deleted) ||
                   IsStateEqual(entity, EntityState.Modified);
        }

        private static bool IsStateEqual(DbEntityEntry entity, EntityState state)
        {
            return (entity.State & state) == state;
        }

        #endregion Privates

        #endregion Methods
    }
}
