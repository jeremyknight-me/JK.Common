using System;

namespace JK.Common.Extensions;

public static class LongExtensions
{
    /// <summary>
    /// Determines whether the specified number is even.
    /// </summary>
    /// <param name="number">The number to check.</param>
    /// <returns><c>true</c> if the number is even; otherwise, <c>false</c>.</returns>
    public static bool IsEven(this long number) => number % 2 == 0;

    /// <summary>
    /// Determines whether the specified number is odd.
    /// </summary>
    /// <param name="number">The number to check.</param>
    /// <returns><c>true</c> if the number is odd; otherwise, <c>false</c>.</returns>
    public static bool IsOdd(this long number) => !IsEven(number);

    /// <summary>
    /// Determines whether the specified number is a prime number.
    /// </summary>
    /// <param name="number">The number to check.</param>
    /// <returns><c>true</c> if the number is prime; otherwise, <c>false</c>.</returns>
    public static bool IsPrime(this long number)
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
}
