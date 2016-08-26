using ContactSearch.DomainModel;
using System;

namespace ContactSearch.ViewModels
{
    /// <summary>
    /// The PersonViewModel view model class.
    /// </summary>
    public class PersonViewModel
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="PersonViewModel"/> class.
        /// </summary>
        /// <param name="model">The model.</param>
        public PersonViewModel(ContactModel model)
        {
            PopulateViewModel(model);
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        public string Id { get; set; }

        /// <summary>
        /// Gets or sets the first name.
        /// </summary>
        /// <value>
        /// The first name.
        /// </value>
        public string FirstName { get; set; }

        /// <summary>
        /// Gets or sets the name of the middle.
        /// </summary>
        /// <value>
        /// The name of the middle.
        /// </value>
        public string MiddleName { get; set; }

        /// <summary>
        /// Gets or sets the last name.
        /// </summary>
        /// <value>
        /// The last name.
        /// </value>
        public string LastName { get; set; }

        /// <summary>
        /// Gets or sets the age.
        /// </summary>
        /// <value>
        /// The age.
        /// </value>
        public int Age { get; set; }

        /// <summary>
        /// Gets or sets the address.
        /// </summary>
        /// <value>
        /// The address.
        /// </value>
        public string Address { get; set; }

        /// <summary>
        /// Gets or sets the city.
        /// </summary>
        /// <value>
        /// The city.
        /// </value>
        public string City { get; set; }

        /// <summary>
        /// Gets or sets the state.
        /// </summary>
        /// <value>
        /// The state.
        /// </value>
        public string State { get; set; }

        /// <summary>
        /// Gets or sets the country.
        /// </summary>
        /// <value>
        /// The country.
        /// </value>
        public string Country { get; set; }

        /// <summary>
        /// Gets or sets the postal code.
        /// </summary>
        /// <value>
        /// The postal code.
        /// </value>
        public string PostalCode { get; set; }

        /// <summary>
        /// Gets or sets the interests.
        /// </summary>
        /// <value>
        /// The interests.
        /// </value>
        public virtual string Interests { get; set; }

        /// <summary>
        /// Gets or sets the photo.
        /// </summary>
        /// <value>
        /// The photo.
        /// </value>
        public virtual byte[] Photo { get; set; }


        #endregion Properties

        #region Methods

        #region Privates

        /// <summary>
        /// Populates the view model.
        /// </summary>
        /// <param name="model">The model.</param>
        private void PopulateViewModel(ContactModel model)
        {
            Id = model.Id.ToString();
            FirstName = model.FirstName;
            MiddleName = model.MiddleName;
            LastName = model.LastName;
            Age = CalculateAge(model.DateOfBirth);
            Address = model.Address;///derive
            Interests = ConvertToCommaSeparated(model.Interests);
            Photo = model.Photo;
            City = model.City;
            State = model.State;
            Country = model.Country;
            PostalCode = model.PostalCode;
        }

        /// <summary>
        /// Calculates the age.
        /// </summary>
        /// <param name="birthday">The birthday.</param>
        /// <returns></returns>
        private static int CalculateAge(DateTime birthday)
        {
            DateTime now = DateTime.Today;
            int age = now.Year - birthday.Year;
            if (now < birthday.AddYears(age))
            {
                age--;
            }

            return age;
        }

        /// <summary>
        /// Converts to comma separated.
        /// </summary>
        /// <param name="strings">The strings.</param>
        /// <returns></returns>
        private string ConvertToCommaSeparated(string [] strings)
        {
            return strings != null ? string.Join(", ", strings) : string.Empty;
        }

        #endregion Privates

        #endregion Methods
    }
}
