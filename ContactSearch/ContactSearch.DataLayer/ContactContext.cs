using ContactSearch.DomainModel;
using System.Data.Entity;

namespace ContactSearch.DataLayer
{
    /// <summary>
    /// The ContactContext class.
    /// </summary>
    /// <seealso cref="System.Data.Entity.DbContext" />
    internal class ContactContext : DbContext
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="ContactContext"/> class.
        /// </summary>
        public ContactContext() : base("ContactContext")
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ContactContext"/> class.
        /// We are not passing the connection string to base class as our requirement is
        /// to create a database in local db using code first approach.
        /// </summary>
        /// <param name="connectionString">The connection string.</param>
        public ContactContext(string connectionString) : base(/*connectionString*/)
        {            
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets the contacts.
        /// </summary>
        /// <value>The contacts.</value>
        public DbSet<ContactModel> Contacts { get; set; }

        #endregion

        #region Methods

        public void FixEfProviderServicesProblem()
        {
            //The Entity Framework provider type 'System.Data.Entity.SqlServer.SqlProviderServices, EntityFramework.SqlServer'
            //for the 'System.Data.SqlClient' ADO.NET provider could not be loaded. 
            //Make sure the provider assembly is available to the running application. 
            //See http://go.microsoft.com/fwlink/?LinkId=260882 for more information.

            var instance = System.Data.Entity.SqlServer.SqlProviderServices.Instance;
        }

        #endregion Methods
    }
}