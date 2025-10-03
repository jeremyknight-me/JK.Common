using System;
using System.Collections.Generic;

namespace JK.Common.Sorting;

/// <summary>
/// Provides an implementation of the shell sort algorithm.
/// </summary>
public static class ShellSort
{
    /// <summary>
    /// Sorts the specified list in ascending order using the shell sort algorithm.
    /// </summary>
    /// <typeparam name="T">The type of elements in the list. Must implement <see cref="IComparable"/> and <see cref="IComparable{T}"/>.</typeparam>
    /// <param name="list">The list to sort.</param>
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
