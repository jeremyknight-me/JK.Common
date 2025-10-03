using System.Collections.Generic;

namespace JK.Common.TypeHelpers;

/// <summary>
/// Provides helper methods for common mathematical operations.
/// </summary>
public static class FibonacciFactory
{
    /// <summary>
    /// Generates a Fibonacci sequence starting with the specified numbers up to the given limit.
    /// </summary>
    /// <param name="first">The first number in the sequence.</param>
    /// <param name="second">The second number in the sequence.</param>
    /// <param name="limit">The number of elements to generate in the sequence.</param>
    /// <returns>An <see cref="IEnumerable{T}"/> containing the Fibonacci sequence.</returns>
    public static IEnumerable<long> Make(in long first, in long second, in int limit)
    {
        List<long> list = [first, second];
        var indexA = 0;
        var indexB = 1;
        while (list.Count <= limit)
        {
            list.Add(list[indexA++] + list[indexB++]);
        }

        return list;
    }
}
