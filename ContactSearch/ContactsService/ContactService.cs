using ContactSearch.ContactsService.Interfaces;
using ContactSearch.ContactsService.Specifications;
using ContactSearch.DataLayer;
using ContactSearch.DataLayer.Interfaces;
using ContactSearch.DataLayer.Specifications;
using ContactSearch.DomainModel;
using System.Collections.Generic;

namespace ContactSearch.ContactsService
{
    /// <summary>
    /// The ContactService class.
    /// This abstracts the APIs that delegates all the CRUD
    /// operations to domain layer.
    /// </summary>
    /// <seealso cref="ContactSearch.ContactsService.Interfaces.IContactService" />
    public class ContactService : IContactService
    {
        #region Fields

        /// <summary>
        /// The repository context.
        /// </summary>
        private ContactRepositoryContext repositoryContext;

        /// <summary>
        /// The repository.
        /// </summary>
        private IRepository<ContactModel, int> repository;

        #endregion Fields

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="ContactService"/> class.
        /// </summary>
        public ContactService()
        {
            //This should be injected from DI container.
            repositoryContext = new ContactRepositoryContext("");
            repository = repositoryContext.GetRepository();
        }

        #endregion Constructors

        #region Methods

        /// <summary>
        /// Gets all contacts.
        /// </summary>
        /// <returns>The contacts.</returns>
        public IEnumerable<ContactModel> GetAllContacts()
        {
            return repository.GetAll();
        }

        /// <summary>
        /// Gets the contacts.
        /// </summary>
        /// <param name="spec">The spec.</param>
        /// <returns>The contacts.</returns>
        public IEnumerable<ContactModel> GetContacts(ContactSpecification spec)
        {
            var entitySpec = new EntitySpecification<ContactModel>(spec.Predicate);
            return repository.GetBySpecification(entitySpec);
        }

        /// <summary>
        /// Saves the contact.
        /// </summary>
        /// <param name="contact">The contact.</param>
        public void SaveContact(ContactModel contact)
        {
            repository.Insert(contact);
        }

        /// <summary>
        /// Saves the contacts.
        /// </summary>
        /// <param name="contacts">The contacts.</param>
        public void SaveContacts(IEnumerable<ContactModel> contacts)
        {
            foreach (var contact in contacts)
            {
                repository.Insert(contact);
            }
            repositoryContext.Commit();
        }

        //We dont implement a service API that deletes all data in the repository, in real project.
        //This is just for demo purpose only.
        /// <summary>
        /// Deletes all contacts.
        /// </summary>
        public void DeleteAllContacts()
        {
            var contacts = repository.GetAll();
            foreach (var contact in contacts)
            {

                repository.Delete(contact.Id);
            }
            repositoryContext.Commit();
        }

        #endregion Methods
    }
}
