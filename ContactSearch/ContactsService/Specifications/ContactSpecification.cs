using ContactSearch.DomainModel;
using ContactsService.Constants;
using ContactsService.Specifications;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace ContactSearch.ContactsService.Specifications
{
    /// <summary>
    /// The ContactSpecification class.
    /// This class abstracts the specification for the
    /// contact to be retrieved from the service.
    /// </summary>
    /// <seealso cref="ContactsService.Specifications.Specification{ContactSearch.DomainModel.ContactModel}" />
    public class ContactSpecification : Specification<ContactModel>
    {
        #region Properties

        /// <summary>
        /// Gets or sets the search key.
        /// </summary>
        /// <value>
        /// The search key.
        /// </value>
        public string SearchKey { get; set; }

        /// <summary>
        /// Gets or sets the properties.
        /// </summary>
        /// <value>
        /// The properties.
        /// </value>
        public List<string> Properties { get; set; }

        #endregion Properties

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="ContactSpecification"/> class.
        /// </summary>
        /// <param name="searchKey">The search key.</param>
        /// <param name="properties">The properties.</param>
        public ContactSpecification(string searchKey, List<string> properties)
        {
            SearchKey = searchKey;
            Properties = properties;
        }

        #endregion Constructors

        #region Methods

        /// <summary>
        /// Gets the predicate.
        /// </summary>
        /// <value>The predicate.</value>
        public override Expression<Func<ContactModel, bool>> Predicate
        {
            get { return GetExpression(); }
        }

        /// <summary>
        /// Gets the expression for the contact.
        /// </summary>
        /// <returns>The expresion.</returns>
        public Expression<Func<ContactModel, bool>> GetExpression()
        {
            Expression<Func<ContactModel, bool>> expression = x => true;

            foreach (var prop in Properties)
            {
                if (prop.Equals(ContactProperties.Name))
                {
                    expression = expression.Ands(x => x.FirstName.Contains(SearchKey, StringComparison.OrdinalIgnoreCase)
                    || x.LastName.Contains(SearchKey, StringComparison.OrdinalIgnoreCase));
                }
                if (prop.Equals(ContactProperties.City))
                {
                    expression = expression.Ands(x => x.City.Contains(SearchKey, StringComparison.OrdinalIgnoreCase));
                }
                if (prop.Equals(ContactProperties.State))
                {
                    expression = expression.Ands(x => x.State.Contains(SearchKey, StringComparison.OrdinalIgnoreCase));
                }
                if (prop.Equals(ContactProperties.PostalCode))
                {
                    expression = expression.Ands(x => x.PostalCode == SearchKey);
                }
            }

            return expression;
        }

        #endregion Methods
    }
}

