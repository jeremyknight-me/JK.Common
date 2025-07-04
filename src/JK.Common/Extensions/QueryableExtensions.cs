using System;
using System.Linq;
using System.Linq.Expressions;

namespace JK.Common.Extensions;

/// <summary>
/// Helper and utility extension methods for <see cref="IQueryable{T}"/>.
/// </summary>
public static class QueryableExtensions
{
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
