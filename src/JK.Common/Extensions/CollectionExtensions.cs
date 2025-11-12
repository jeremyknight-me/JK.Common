namespace JK.Common.Extensions;

/// <summary>
/// Helper and utility extension methods for <see cref="ICollection{T}"/> and <see cref="IReadOnlyCollection{T}"/>.
/// </summary>
public static class CollectionExtensions
{
    extension<T>(ICollection<T> collection)
    {
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
