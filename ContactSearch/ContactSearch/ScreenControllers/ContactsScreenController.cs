using ContactSearch.ContactsService.Interfaces;
using ContactSearch.ContactsService.Specifications;
using ContactSearch.DomainModel;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ContactSearch.ScreenControllers
{
    /// <summary>
    /// The ContactsScreenController class.
    /// </summary>
    /// <seealso cref="ContactSearch.ScreenControllers.IContactsScreenController" />
    public class ContactsScreenController : IContactsScreenController
    {
        #region Fields

        /// <summary>
        /// The service.
        /// </summary>
        private IContactService service = new ContactsService.ContactService();

        #endregion Fields

        #region Properties

        /// <summary>
        /// Gets the service.
        /// </summary>
        /// <value>
        /// The service.
        /// </value>
        public IContactService Service
        {
            get
            {
                return service;
            }
        }

        #endregion Properties

        #region Methods

        #region Methods Implementation

        /// <summary>
        /// Deletes all contacts.
        /// </summary>
        /// <returns></returns>
        public async Task DeleteAllContacts()
        {
            await Task.Run(() => Service.DeleteAllContacts());
        }

        /// <summary>
        /// Gets all contacts.
        /// </summary>
        /// <returns>
        /// The task.
        /// </returns>
        public async Task<IEnumerable<ContactModel>> GetAllContacts()
        {
            return await Task.Run(() => Service.GetAllContacts());
        }

        /// <summary>
        /// Gets the contacts.
        /// </summary>
        /// <param name="spec">The spec.</param>
        /// <returns>
        /// The task.
        /// </returns>
        public async Task<IEnumerable<ContactModel>> GetContacts(ContactSpecification spec)
        {
            await Task.Delay(30000);
            return await Task.Run(() => Service.GetContacts(spec));
        }

        /// <summary>
        /// Saves the contact.
        /// </summary>
        /// <param name="contact">The contact.</param>
        /// <returns>
        /// The task.
        /// </returns>
        public async Task SaveContact(ContactModel contact)
        {
            await Task.Run(() => Service.SaveContact(contact));
        }

        /// <summary>
        /// Saves the contacts.
        /// </summary>
        /// <param name="contacts">The contacts.</param>
        /// <returns>
        /// The task.
        /// </returns>
        public async Task SaveContacts(IEnumerable<ContactModel> contacts)
        {
            await Task.Run(() => Service.SaveContacts(contacts));
        }

        #endregion Methods Implementation

        #endregion Methods 
    }
}
