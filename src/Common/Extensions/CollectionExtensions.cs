namespace JK.Common.Extensions;

/// <summary>
/// Helper and utility extension methods for <see cref="ICollection{T}"/> and <see cref="IReadOnlyCollection{T}"/>.
/// </summary>
public static class CollectionExtensions
{
    extension<T>(ICollection<T> collection)
    {
        /// <summary>
        /// Adds the specified item to the collection if the item is not <c>null</c>.
        /// </summary>
        /// <param name="item">The item to add to the collection.</param>
        public void AddIfNotNull(T item)
        {
            ThrowHelper.IfNull(collection, nameof(collection));
            if (item is null)
            {
                return;
            }

            collection.Add(item);
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
            ThrowHelper.IfNull(collection, nameof(collection));
            if (items is null)
            {
                return;
            }

            foreach (T item in items)
            {
                if (item is not null)
                {
                    collection.Add(item);
                }
            }
        }

        /// <summary>
        /// Determines whether the collection has any items.
        /// </summary>
        /// <returns><c>true</c> if the collection has items; otherwise, <c>false</c>.</returns>
        public bool HasItems => collection.Count > 0;
    }

    extension<T>(IReadOnlyCollection<T> collection)
    {
        /// <summary>
        /// Determines whether the read-only collection has any items.
        /// </summary>
        /// <returns><c>true</c> if the collection has items; otherwise, <c>false</c>.</returns>
        public bool HasItems => collection.Count > 0;
    }
}
