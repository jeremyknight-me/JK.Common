using System.Collections.Concurrent;

namespace JK.Common.Extensions;

/// <summary>
/// Helper and utility extension methods for <see cref="ConcurrentBag{T}"/>.
/// </summary>
public static class ConcurrentBagExtensions
{
    /// <summary>
    /// Adds a range of items to the <see cref="ConcurrentBag{T}"/>.
    /// </summary>
    /// <typeparam name="T">The type of the elements in the bag.</typeparam>
    /// <param name="bag">The bag to add items to.</param>
    /// <param name="list">The items to add.</param>
    public static void AddRange<T>(this ConcurrentBag<T> bag, in IEnumerable<T> list)
    {
        foreach (T item in list)
        {
            bag.Add(item);
        }
    }
}
