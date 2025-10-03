#if !NET6_0_OR_GREATER
using JK.Common.TypeHelpers;
#endif

using System;
using System.Collections.Generic;
using System.Linq;

namespace JK.Common.Extensions;

/// <summary>
/// Helper and utility extension methods for <see cref="IEnumerable{T}"/>.
/// </summary>
public static class EnumerableExtensions
{
#if !NET6_0_OR_GREATER
    /// <summary>
    /// Returns distinct elements from a sequence by using a specified key selector.
    /// </summary>
    /// <typeparam name="TSource">The type of the elements of source.</typeparam>
    /// <typeparam name="TValue">The type of the key returned by selector.</typeparam>
    /// <param name="source">The sequence to remove duplicate elements from.</param>
    /// <param name="selector">A function to extract the key for each element.</param>
    /// <returns>An IEnumerable that contains distinct elements from the source sequence.</returns>
    public static IEnumerable<TSource> DistinctBy<TSource, TValue>(this IEnumerable<TSource> source, Func<TSource, TValue> selector)
    {
        IEqualityComparer<TSource> comparer = ProjectionComparer<TSource>.CompareBy(selector, EqualityComparer<TValue>.Default);
        return new HashSet<TSource>(source, comparer);
    }
#endif

    /// <summary>
    /// Performs the specified action on each element of the IEnumerable.
    /// </summary>
    /// <typeparam name="T">The type of the elements of source.</typeparam>
    /// <param name="source">The sequence to iterate over.</param>
    /// <param name="action">The action to perform on each element.</param>
    public static void ForEach<T>(this IEnumerable<T> source, in Action<T> action)
    {
        foreach (T item in source)
        {
            action(item);
        }
    }

    /// <summary>
    /// Returns a sequence of tuples containing the element and its index.
    /// </summary>
    /// <typeparam name="T">The type of the elements of source.</typeparam>
    /// <param name="source">The sequence to index.</param>
    /// <returns>An IEnumerable of tuples where each tuple contains an element and its index.</returns>
    public static IEnumerable<(T item, int index)> AsIndexedEnumerable<T>(this IEnumerable<T> source)
        => source.Select((item, index) => (item, index));
}
