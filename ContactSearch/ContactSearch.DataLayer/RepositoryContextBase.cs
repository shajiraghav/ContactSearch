using ContactSearch.DataLayer.Interfaces;
using System;

namespace ContactSearch.DataLayer
{
    /// <summary>
    /// The generic RepositoryContextBase abstract class.
    /// </summary>
    /// <typeparam name="TEntity">The type of the entity.</typeparam>
    /// <typeparam name="TIdentifier">The type of the identifier.</typeparam>
    /// <seealso cref="ContactSearch.DataLayer.Interfaces.IRepositoryContext{TEntity, TIdentifier}" />
    /// <seealso cref="System.IDisposable" />
    public abstract class RepositoryContextBase<TEntity, TIdentifier> : IRepositoryContext<TEntity, TIdentifier>, IDisposable where TEntity : class
    {
        #region IRepositoryContext implementation

        /// <summary>
        /// Afters the commit.
        /// </summary>
        /// <param name="args">The <see cref="AfterCommitEventArgs" /> instance containing the event data.</param>
        /// <returns></returns>
        public abstract EventHandler AfterCommit(AfterCommitEventArgs args);

        /// <summary>
        /// Befores the commit.
        /// </summary>
        /// <param name="args">The <see cref="BeforeRollbackeEventArgs" /> instance containing the event data.</param>
        /// <returns></returns>
        public abstract EventHandler BeforeCommit(BeforeRollbackeEventArgs args);

        /// <summary>
        /// Commits this instance.
        /// </summary>
        /// <returns></returns>
        public abstract int Commit();

        /// <summary>
        /// Gets the repository.
        /// </summary>
        /// <returns></returns>
        public abstract IRepository<TEntity, TIdentifier> GetRepository();

        /// <summary>
        /// Rollbacks this instance.
        /// </summary>
        public abstract void Rollback();

        #endregion IRepositoryContext implementation

        #region IDisposable implementation

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
        }

        /// <summary>
        /// Releases unmanaged and - optionally - managed resources.
        /// </summary>
        /// <param name="disposing"><c>true</c> to release both managed and unmanaged resources; <c>false</c> to release only unmanaged resources.</param>
        public abstract void Dispose(bool disposing);        

        #endregion IDisposable implementation
    }
}
