using System.Linq;
using System.Linq.Expressions;

namespace JK.Common.Extensions;

/// <summary>
/// Helper and utility extension methods for <see cref="IQueryable{T}"/>.
/// </summary>
public static class QueryableExtensions
{
    extension<TSource>(IQueryable<TSource> source)
    {
        /// <summary>
        /// Sorts the elements of a sequence in ascending or descending order according to a key.
        /// </summary>
        /// <typeparam name="TKey">The type of the key returned by keySelector.</typeparam>
        /// <param name="keySelector">A function to extract a key from an element.</param>
        /// <param name="isAscending">True to sort ascending, false for descending.</param>
        /// <returns>An <see cref="IQueryable{T}"/> whose elements are sorted according to a key.</returns>
        public IQueryable<TSource> SortBy<TKey>(in Func<TSource, TKey> keySelector, in bool isAscending = true)
        {
            if (source is null)
            {
                throw new ArgumentNullException(nameof(source));
            }

            if (keySelector is null)
            {
                return source;
            }

            return isAscending
                ? source.OrderBy(keySelector).AsQueryable()
                : source.OrderByDescending(keySelector).AsQueryable();
        }

        /// <summary>
        /// Sorts the elements of a sequence in ascending or descending order according to a property name.
        /// </summary>
        /// <param name="propertyName">The name of the property to sort by.</param>
        /// <param name="ascending">True to sort ascending, false for descending.</param>
        /// <returns>An <see cref="IQueryable{T}"/> whose elements are sorted according to the property name.</returns>
        public IQueryable<TSource> SortBy(in string propertyName, in bool ascending = true)
        {
            if (source is null)
            {
                throw new ArgumentNullException(nameof(source));
            }

            if (string.IsNullOrEmpty(propertyName))
            {
                return source;
            }

            ParameterExpression parameter = Expression.Parameter(source.ElementType, string.Empty);
            MemberExpression property = Expression.Property(parameter, propertyName);
            LambdaExpression lambda = Expression.Lambda(property, parameter);

            var methodName = ascending ? "OrderBy" : "OrderByDescending";

            Expression methodCallExpression
                = Expression.Call(typeof(Queryable),
                    methodName,
                    [source.ElementType, property.Type],
                    source.Expression,
                    Expression.Quote(lambda));
            return source.Provider.CreateQuery<TSource>(methodCallExpression);
        }

        /// <summary>
        /// Filters a sequence based on a condition.
        /// </summary>
        /// <param name="condition">A boolean value to determine if the predicate should be applied.</param>
        /// <param name="predicate">A function to test each element for a condition.</param>
        /// <returns>An <see cref="IQueryable{T}"/> that contains elements from the input sequence that satisfy the condition if true, otherwise the original sequence.</returns>
        public IQueryable<TSource> WhereIf(in bool condition, in Expression<Func<TSource, bool>> predicate)
        {
            if (source is null)
            {
                throw new ArgumentNullException(nameof(source));
            }

            return condition
                ? source.Where(predicate)
                : source;
        }
    }
}
