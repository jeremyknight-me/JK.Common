using System.Collections.Generic;

namespace JK.Common.Extensions;

public static class CollectionExtensions
{
    public static bool HasItems<T>(this ICollection<T> collection) => collection.Count > 0;
    public static bool HasItems<T>(this IReadOnlyCollection<T> collection) => collection.Count > 0;
}
