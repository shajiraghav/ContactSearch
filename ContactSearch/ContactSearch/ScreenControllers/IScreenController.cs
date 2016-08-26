using ContactSearch.ContactsService.Interfaces;

namespace ContactSearch.ScreenControllers
{
    /// <summary>
    /// The IScreenController interface.
    /// </summary>
    public interface IScreenController
    {
        /// <summary>
        /// Gets the service.
        /// </summary>
        /// <value>
        /// The service.
        /// </value>
        IContactService Service { get; }
    }
}
