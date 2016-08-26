using ContactSearch.ContactsService.Specifications;
using ContactSearch.DomainModel;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ContactSearch.ScreenControllers
{
    /// <summary>
    /// The IContactsScreenController interface.
    /// </summary>
    /// <seealso cref="ContactSearch.ScreenControllers.IScreenController" />
    public interface IContactsScreenController : IScreenController
    {
        #region Contracts

        /// <summary>
        /// Saves the contact.
        /// </summary>
        /// <param name="contact">The contact.</param>
        /// <returns>The task.</returns>
        Task SaveContact(ContactModel contact);

        /// <summary>
        /// Saves the contacts.
        /// </summary>
        /// <param name="contacts">The contacts.</param>
        /// <returns>The task.</returns>
        Task SaveContacts(IEnumerable<ContactModel> contacts);

        /// <summary>
        /// Gets all contacts.
        /// </summary>
        /// <returns>The task.</returns>
        Task<IEnumerable<ContactModel>> GetAllContacts();

        /// <summary>
        /// Gets the contacts.
        /// </summary>
        /// <param name="spec">The spec.</param>
        /// <returns>The task.</returns>
        Task<IEnumerable<ContactModel>> GetContacts(ContactSpecification spec);

        //We dont implement a service API that deletes all data in the repository, in real project.
        //This is just for demo purpose only.
        /// <summary>
        /// Deletes all contacts.
        /// </summary>
        /// <returns></returns>
        Task DeleteAllContacts();

        #endregion Contracts
    }
}
