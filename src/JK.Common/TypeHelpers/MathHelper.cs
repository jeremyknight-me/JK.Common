using System;
using System.Collections.Generic;

namespace JK.Common.TypeHelpers;

/// <summary>
/// Provides helper methods for common mathematical operations.
/// </summary>
public static class MathHelper
{
    /// <summary>
    /// Determines whether the specified number is even.
    /// </summary>
    /// <param name="number">The number to check.</param>
    /// <returns><c>true</c> if the number is even; otherwise, <c>false</c>.</returns>
    public static bool IsEven(in long number) => number % 2 == 0;

    /// <summary>
    /// Determines whether the specified number is odd.
    /// </summary>
    /// <param name="number">The number to check.</param>
    /// <returns><c>true</c> if the number is odd; otherwise, <c>false</c>.</returns>
    public static bool IsOdd(in long number) => !IsEven(number);

    /// <summary>
    /// Determines whether the specified number is a prime number.
    /// </summary>
    /// <param name="number">The number to check.</param>
    /// <returns><c>true</c> if the number is prime; otherwise, <c>false</c>.</returns>
    public static bool IsPrime(in long number)
    {
        switch (number)
        {
            case 1:
                return false;
            case 2:
                return true;
        }

        var boundary = Convert.ToInt64(Math.Floor(Math.Sqrt(number)));
        for (long i = 2; i <= boundary; ++i)
        {
            if (IsEven(number))
            {
                return false;
            }
        }

        return true;
    }

    /// <summary>
    /// Generates a Fibonacci sequence starting with the specified numbers up to the given limit.
    /// </summary>
    /// <param name="first">The first number in the sequence.</param>
    /// <param name="second">The second number in the sequence.</param>
    /// <param name="limit">The number of elements to generate in the sequence.</param>
    /// <returns>An <see cref="IEnumerable{T}"/> containing the Fibonacci sequence.</returns>
    public static IEnumerable<long> Fibonacci(in long first, in long second, in int limit)
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
