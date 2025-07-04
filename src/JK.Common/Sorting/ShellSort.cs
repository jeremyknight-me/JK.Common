using System;
using System.Collections.Generic;

namespace JK.Common.Sorting;

public static class ShellSort
{
    public static void Sort<T>(IList<T> list) where T : IComparable, IComparable<T>
    {
        var n = list.Count;
        var gap = n / 2;
        while (gap > 0)
        {
            for (var i = gap; i < n; i++)
            {
                T temp = list[i];
                var j = i;
                while (j >= gap && list[j - gap].CompareTo(temp) > 0)
                {
                    list[j] = list[j - gap];
                    j -= gap;
                }

                list[j] = temp;
            }

            gap /= 2;
        }
    }
}
