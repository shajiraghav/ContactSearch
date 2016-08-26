using ContactSearch.ContactsService.Specifications;
using ContactSearch.DomainModel;
using System.Collections.Generic;

namespace ContactSearch.ContactsService.Interfaces
{
    /// <summary>
    /// The IContactService interface.
    /// </summary>
    public interface IContactService
    {
        #region Contracts

        /// <summary>
        /// Saves the contact.
        /// </summary>
        /// <param name="contact">The contact.</param>
        void SaveContact(ContactModel contact);

        /// <summary>
        /// Saves the contacts.
        /// </summary>
        /// <param name="contacts">The contacts.</param>
        void SaveContacts(IEnumerable<ContactModel> contacts);

        /// <summary>
        /// Gets all contacts.
        /// </summary>
        /// <returns></returns>
        IEnumerable<ContactModel> GetAllContacts();

        /// <summary>
        /// Gets the contacts.
        /// </summary>
        /// <param name="spec">The spec.</param>
        /// <returns></returns>
        IEnumerable<ContactModel> GetContacts(ContactSpecification spec);

        //We dont implement a service API that deletes all data in the repository, in real project.
        //This is just for demo purpose only.
        /// <summary>
        /// Deletes all contacts.
        /// </summary>
        void DeleteAllContacts();

        #endregion Contracts
    }
}
