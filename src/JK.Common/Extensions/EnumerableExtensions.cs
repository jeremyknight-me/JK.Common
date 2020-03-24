using JK.Common.TypeHelpers;
using System;
using System.Collections.Generic;

namespace JK.Common.Extensions
{
    public static class EnumerableExtensions
    {
        public static IEnumerable<TSource> DistinctBy<TSource, TValue>(this IEnumerable<TSource> source, Func<TSource, TValue> selector)
        {
            var comparer = ProjectionComparer<TSource>.CompareBy(selector, EqualityComparer<TValue>.Default);
            return new HashSet<TSource>(source, comparer);
        }

        public static void ForEach<T>(this IEnumerable<T> source, Action<T> action)
        {
            foreach (var item in source)
            {
                action(item);
            }
        }
    }
}
