using System.Collections.Concurrent;

namespace JK.Common.Extensions;

/// <summary>
/// Helper and utility extension methods for <see cref="ConcurrentBag{T}"/>.
/// </summary>
public static class ConcurrentBagExtensions
{
    extension<T>(ConcurrentBag<T> bag)
    {
        /// <summary>
        /// Adds a range of items to the <see cref="ConcurrentBag{T}"/>.
        /// </summary>
        /// <param name="list">The items to add.</param>
        public void AddRange(in IEnumerable<T> list)
        {
            foreach (T item in list)
            {
                bag.Add(item);
            }
        }
    }
}
