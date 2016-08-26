using System;

namespace ContactSearch.DataLayer.Interfaces
{
    /// <summary>
    /// The IUnitOfWork interface.
    /// </summary>
    public interface IUnitOfWork
    {
        #region Methods

        /// <summary>
        /// Commits this instance.
        /// </summary>
        /// <returns></returns>
        int Commit();

        /// <summary>
        /// Rollbacks this instance.
        /// </summary>
        void Rollback();

        #endregion

        #region EventHandler

        /// <summary>
        /// Afters the commit.
        /// </summary>
        /// <param name="args">The <see cref="AfterCommitEventArgs"/> instance containing the event data.</param>
        /// <returns></returns>
        EventHandler AfterCommit(AfterCommitEventArgs args);

        /// <summary>
        /// Befores the commit.
        /// </summary>
        /// <param name="args">The <see cref="BeforeRollbackeEventArgs"/> instance containing the event data.</param>
        /// <returns></returns>
        EventHandler BeforeCommit(BeforeRollbackeEventArgs args);

        #endregion
    }
}
