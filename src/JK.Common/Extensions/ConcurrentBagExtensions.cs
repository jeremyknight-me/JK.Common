using System.Collections.Concurrent;
using System.Collections.Generic;

namespace JK.Common.Extensions;

public static class ConcurrentBagExtensions
{
    public static void AddRange<T>(this ConcurrentBag<T> bag, in IEnumerable<T> list)
    {
        foreach (var item in list)
        {
            bag.Add(item);
        }
    }
}
