using System;
using System.Linq.Expressions;

namespace ContactSearch.DataLayer.Specifications
{
    /// <summary>
    /// The generic EntitySpecification class.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class EntitySpecification<T>
    {
        #region Fields

        /// <summary>
        /// The expression.
        /// </summary>
        private readonly Expression<Func<T, bool>> expression;

        /// <summary>
        /// The evaluate expression.
        /// </summary>
        private Func<T, bool> evaluateExpression;

        #endregion Fields

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="EntitySpecification{T}"/> class.
        /// </summary>
        /// <param name="predicate">The predicate.</param>
        public EntitySpecification(Expression<Func<T, bool>> predicate)
        {
            this.expression = predicate;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="EntitySpecification{T}"/> class.
        /// </summary>
        protected EntitySpecification()
        {
        }

        #endregion Constructors

        #region Methods

        /// <summary>
        /// Gets the predicate.
        /// </summary>
        /// <value>
        /// The predicate.
        /// </value>
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
        /// <returns></returns>
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
