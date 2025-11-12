using System.Linq;
using System.Linq.Expressions;

namespace JK.Common.Extensions;

/// <summary>
/// Helper and utility extension methods for <see cref="IQueryable{T}"/>.
/// </summary>
public static class QueryableExtensions
{
    /// <summary>
    /// Sorts the elements of a sequence in ascending or descending order according to a key.
    /// </summary>
    /// <typeparam name="TSource">The type of the elements of source.</typeparam>
    /// <typeparam name="TKey">The type of the key returned by keySelector.</typeparam>
    /// <param name="source">An <see cref="IQueryable{T}"/> to order.</param>
    /// <param name="keySelector">A function to extract a key from an element.</param>
    /// <param name="isAscending">True to sort ascending, false for descending.</param>
    /// <returns>An <see cref="IQueryable{T}"/> whose elements are sorted according to a key.</returns>
    public static IQueryable<TSource> SortBy<TSource, TKey>(this IQueryable<TSource> source, in Func<TSource, TKey> keySelector, in bool isAscending = true)
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
    /// <typeparam name="T">The type of the elements of source.</typeparam>
    /// <param name="source">An <see cref="IQueryable{T}"/> to order.</param>
    /// <param name="propertyName">The name of the property to sort by.</param>
    /// <param name="ascending">True to sort ascending, false for descending.</param>
    /// <returns>An <see cref="IQueryable{T}"/> whose elements are sorted according to the property name.</returns>
    public static IQueryable<T> SortBy<T>(this IQueryable<T> source, in string propertyName, in bool ascending = true)
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
        return source.Provider.CreateQuery<T>(methodCallExpression);
    }

    /// <summary>
    /// Filters a sequence based on a condition.
    /// </summary>
    /// <typeparam name="TSource">The type of the elements of source.</typeparam>
    /// <param name="source">An <see cref="IQueryable{T}"/> to filter.</param>
    /// <param name="condition">A boolean value to determine if the predicate should be applied.</param>
    /// <param name="predicate">A function to test each element for a condition.</param>
    /// <returns>An <see cref="IQueryable{T}"/> that contains elements from the input sequence that satisfy the condition if true, otherwise the original sequence.</returns>
    public static IQueryable<TSource> WhereIf<TSource>(this IQueryable<TSource> source, in bool condition, in Expression<Func<TSource, bool>> predicate)
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
