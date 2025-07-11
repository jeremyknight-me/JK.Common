﻿#if !NET6_0_OR_GREATER
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
        public static IEnumerable<TSource> DistinctBy<TSource, TValue>(this IEnumerable<TSource> source, Func<TSource, TValue> selector)
        {
            IEqualityComparer<TSource> comparer = ProjectionComparer<TSource>.CompareBy(selector, EqualityComparer<TValue>.Default);
            return new HashSet<TSource>(source, comparer);
        }
#endif

    public static void ForEach<T>(this IEnumerable<T> source, in Action<T> action)
    {
        foreach (T item in source)
        {
            action(item);
        }
    }

    public static IEnumerable<(T item, int index)> AsIndexedEnumerable<T>(this IEnumerable<T> source)
        => source.Select((item, index) => (item, index));
}
