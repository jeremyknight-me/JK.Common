using System.Collections.Generic;

namespace JK.Common.Extensions;

/// <summary>
/// Helper and utility extension methods for <see cref="ICollection{T}"/> and <see cref="IReadOnlyCollection{T}"/>.
/// </summary>
public static class CollectionExtensions
{
    /// <summary>
    /// Determines whether the collection has any items.
    /// </summary>
    /// <typeparam name="T">The type of the elements in the collection.</typeparam>
    /// <param name="collection">The collection to check.</param>
    /// <returns><c>true</c> if the collection has items; otherwise, <c>false</c>.</returns>
    public static bool HasItems<T>(this ICollection<T> collection) => collection.Count > 0;

    /// <summary>
    /// Determines whether the read-only collection has any items.
    /// </summary>
    /// <typeparam name="T">The type of the elements in the collection.</typeparam>
    /// <param name="collection">The read-only collection to check.</param>
    /// <returns><c>true</c> if the collection has items; otherwise, <c>false</c>.</returns>
    public static bool HasItems<T>(this IReadOnlyCollection<T> collection) => collection.Count > 0;
}
