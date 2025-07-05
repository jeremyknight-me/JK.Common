using System;
using System.Collections.Generic;

namespace JK.Common.TypeHelpers;

public static class MathHelper
{
    public static bool IsEven(in long number) => number % 2 == 0;

    public static bool IsOdd(in long number) => !IsEven(number);

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
