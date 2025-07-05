using System.Collections.Concurrent;
using System.Collections.Generic;

namespace JK.Common.Extensions;

/// <summary>
/// Helper and utility extension methods for <see cref="ConcurrentBag{T}"/>.
/// </summary>
public static class ConcurrentBagExtensions
{
    public static void AddRange<T>(this ConcurrentBag<T> bag, in IEnumerable<T> list)
    {
        foreach (T item in list)
        {
            bag.Add(item);
        }
    }
}
