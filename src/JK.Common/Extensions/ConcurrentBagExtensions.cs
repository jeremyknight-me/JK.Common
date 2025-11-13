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

        /// <summary>
        /// Adds the specified items to the collection if they are not <c>null</c>.
        /// </summary>
        /// <param name="items">The items to add to the collection.</param>
        /// <remarks>
        /// Each item in <paramref name="items"/> will be checked for <c>null</c> before being added.
        /// </remarks>
        public void AddRangeIfNotNull(IEnumerable<T> items)
        {
            ThrowHelper.IfNull(bag, nameof(bag));
            if (items is null)
            {
                return;
            }

            foreach (T item in items)
            {
                if (item is not null)
                {
                    bag.Add(item);
                }
            }
        }
    }
}
