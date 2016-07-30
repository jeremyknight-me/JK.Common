using System;
using System.Linq.Expressions;

namespace DL.Core.Linq.Expressions
{
    /// <summary>
    /// Class which uses the <seealso cref="System.Linq.Expressions" /> namespace to dynamically build
    /// expressions for advanced querying interfaces.
    /// </summary>
    /// <typeparam name="T">Type to filter</typeparam>
    public class ExpressionFilter<T>
    {
        /// <summary>
        /// Initializes a new instance of the ExpressionFilter class.
        /// </summary>
        public ExpressionFilter()
        {
            this.MemberExpression = null;
            this.FilterType = ExpressionFilterType.Equals;
            this.CompositeType = ExpressionCompositeType.And;
        }

        /// <summary>
        /// Gets or sets the filter type.
        /// </summary>
        public ExpressionFilterType FilterType { get; set; }

        /// <summary>
        /// Gets or sets the composite type of the filter such as And or Or.
        /// </summary>
        public ExpressionCompositeType CompositeType { get; set; }

        /// <summary>
        /// Gets or sets the value to filter by.
        /// </summary>
        public object Value { get; set; }

        /// <summary>
        /// Gets or sets the second value to filter by.
        /// Should only be used with one of the Between FilterTypes.
        /// </summary>
        public object ValueTwo { get; set; }

        /// <summary>
        /// Gets the member expression to be used.
        /// </summary>
        public MemberExpression MemberExpression { get; private set; }

        public void SetMemberExpression<TProperty>(Expression<Func<T, TProperty>> propertyLambda)
        {
            this.MemberExpression = propertyLambda.Body as MemberExpression;
            if (this.MemberExpression == null)
            {
                throw new ArgumentException(string.Format("Expression '{0}' refers to a method, not a property.", propertyLambda));
            }
        }
    }
}
