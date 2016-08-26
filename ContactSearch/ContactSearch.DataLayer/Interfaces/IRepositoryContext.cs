namespace ContactSearch.DataLayer.Interfaces
{
    /// <summary>
    /// The generic IRepositoryContext interface.
    /// </summary>
    /// <typeparam name="TEntity">The type of the entity.</typeparam>
    /// <typeparam name="TIdentifier">The type of the identifier.</typeparam>
    /// <seealso cref="ContactSearch.DataLayer.Interfaces.IUnitOfWork" />
    public interface IRepositoryContext<TEntity, TIdentifier> : IUnitOfWork where TEntity : class
    {
        /// <summary>
        /// Gets the repository.
        /// </summary>
        /// <returns></returns>
        IRepository<TEntity, TIdentifier> GetRepository();
    }
}
