using ContactSearch.DataLayer.Interfaces;
using ContactSearch.DomainModel;

namespace ContactSearch.DataLayer
{
    /// <summary>
    /// The ContactRepositoryContext class.
    /// </summary>
    /// <seealso cref="ContactSearch.DataLayer.EFRepositoryContext{ContactSearch.DomainModel.ContactModel, System.Int32}" />
    public class ContactRepositoryContext : EFRepositoryContext<ContactModel, int>
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="ContactRepositoryContext"/> class.
        /// </summary>
        /// <param name="connectionString">The connection string.</param>
        public ContactRepositoryContext(string connectionString) : base(connectionString)
        {
            dbContext = new ContactContext(connectionString);
        }

        #endregion Constructors

        #region Methods

        #region RepositoryContextBase implementation

        /// <summary>
        /// Gets the repository.
        /// </summary>
        /// <returns>The repository.</returns>
        public override IRepository<ContactModel, int> GetRepository()
        {
            return new ContactRepository(dbContext);
        }

        /// <summary>
        /// Releases unmanaged and - optionally - managed resources.
        /// </summary>
        /// <param name="disposing"><c>true</c> to release both managed and unmanaged resources; <c>false</c> to release only unmanaged resources.</param>
        public override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (this.dbContext != null)
                {
                    this.dbContext.Dispose();
                    this.dbContext = null;
                }
            }
        }

        #endregion

        #endregion Methods
    }
}
