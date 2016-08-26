using System;
using System.Linq.Expressions;

namespace ContactsService.Specifications
{
    /// <summary>
    /// The generic Specification class.
    /// </summary>
    /// <typeparam name="T">The type.</typeparam>
    public class Specification<T> where T : class
    {
        #region Fields

        /// <summary>
        /// The expression
        /// </summary>
        private readonly Expression<Func<T, bool>> expression;

        /// <summary>
        /// The evaluate expression
        /// </summary>
        private Func<T, bool> evaluateExpression;

        #endregion Fields
        
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="Specification{T}"/> class.
        /// </summary>
        /// <param name="predicate">The predicate.</param>
        public Specification(Expression<Func<T, bool>> predicate)
        {
            this.expression = predicate;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Specification{T}"/> class.
        /// </summary>
        protected Specification()
        {
        }

        #endregion Constructors

        #region Methods

        /// <summary>
        /// Gets the predicate.
        /// </summary>
        /// <value>The predicate.</value>
        /// <exception cref="System.NotImplementedException"></exception>
        public virtual Expression<Func<T, bool>> Predicate
        {
            get
            {
                if (expression != null)
                {
                    return expression;
                }
                throw new NotImplementedException();
            }
        }

        /// <summary>
        /// Determines whether [is satisfied by] [the specified candidate].
        /// </summary>
        /// <param name="candidate">The candidate.</param>
        /// <returns>True, if satisfied.</returns>
        public bool IsSatisfiedBy(T candidate)
        {
            if (evaluateExpression == null)
            {
                evaluateExpression = expression.Compile();
            }
            return evaluateExpression(candidate);
        }

        #endregion Methods
    }
}

