using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace JK.Common.Extensions
{
    public static class ConcurrentBagExtensions
    {
        public static void AddRange<T>(this ConcurrentBag<T> bag, IEnumerable<T> list)
        {
            _ = Parallel.ForEach(list, (item) =>
            {
                bag.Add(item);
            });
        }
    }
}
