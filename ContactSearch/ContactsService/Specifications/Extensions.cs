using System;
using System.Linq.Expressions;

namespace ContactSearch.ContactsService.Specifications
{
    /// <summary>
    /// The Extensions class.
    /// </summary>
    public static class Extensions
    {
        #region Methods

        /// <summary>
        /// Andses the specified expr2.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="expr1">The expr1.</param>
        /// <param name="expr2">The expr2.</param>
        /// <returns></returns>
        public static Expression<Func<T, bool>> Ands<T>(this Expression<Func<T, bool>> expr1, Expression<Func<T, bool>> expr2)
        {
            var parameter = Expression.Parameter(typeof(T));

            var leftVisitor = new ExpressionVisitorEx(expr1.Parameters[0], parameter);
            var left = leftVisitor.Visit(expr1.Body);

            var rightVisitor = new ExpressionVisitorEx(expr2.Parameters[0], parameter);
            var right = rightVisitor.Visit(expr2.Body);

            return Expression.Lambda<Func<T, bool>>(
                Expression.And(left, right), parameter);
        }

        /// <summary>
        /// Determines whether [contains] [the specified to check].
        /// </summary>
        /// <param name="source">The source.</param>
        /// <param name="toCheck">To check.</param>
        /// <param name="comp">The comp.</param>
        /// <returns>True if succeeds.</returns>
        public static bool Contains(this string source, string toCheck, StringComparison comp)
        {
            return source != null && toCheck != null && source.IndexOf(toCheck, comp) >= 0;
        }

        #endregion Methods

        #region Inner Class

        /// <summary>
        /// The ExpressionVisitorEx class.
        /// </summary>
        /// <seealso cref="System.Linq.Expressions.ExpressionVisitor" />
        private class ExpressionVisitorEx: ExpressionVisitor
        {
            #region Fields

            /// <summary>
            /// The old value
            /// </summary>
            private readonly Expression _oldValue;
            /// <summary>
            /// The new value
            /// </summary>
            private readonly Expression _newValue;

            #endregion Fields

            #region Methods

            /// <summary>
            /// Initializes a new instance of the <see cref="ExpressionVisitorEx"/> class.
            /// </summary>
            /// <param name="oldValue">The old value.</param>
            /// <param name="newValue">The new value.</param>
            public ExpressionVisitorEx(Expression oldValue, Expression newValue)
            {
                _oldValue = oldValue;
                _newValue = newValue;
            }

            /// <summary>
            /// Dispatches the expression to one of the more specialized visit methods in this class.
            /// </summary>
            /// <param name="node">The expression to visit.</param>
            /// <returns>
            /// The modified expression, if it or any subexpression was modified; otherwise, returns the original expression.
            /// </returns>
            public override Expression Visit(Expression node)
            {
                if (node == _oldValue)
                    return _newValue;
                return base.Visit(node);
            }

            #endregion Methods
        }

        #endregion Inner Class
    }
}
