using System;
using System.Collections.Generic;

namespace JK.Common.Sorting;

/// <summary>
/// Provides an implementation of the heap sort algorithm.
/// </summary>
public static class HeapSort
{
    /// <summary>
    /// Sorts the specified list in ascending order using the heap sort algorithm.
    /// </summary>
    /// <typeparam name="T">The type of elements in the list. Must implement <see cref="IComparable"/> and <see cref="IComparable{T}"/>.</typeparam>
    /// <param name="list">The list to sort.</param>
    public static void Sort<T>(IList<T> list) where T : IComparable, IComparable<T>
    {
        MakeHeap(list, list.Count);
        for (var i = list.Count - 1; i > 0; i--)
        {
            (list[0], list[i]) = (list[i], list[0]);
            MakeHeap(list, i);
        }
    }

    private static void MakeHeap<T>(IList<T> list, int c)
        where T : IComparable, IComparable<T>
    {
        for (var i = 1; i < c; i++)
        {
            T value = list[i];
            var s = i;
            var f = (s - 1) / 2;
            while (s > 0 && list[f].CompareTo(value) < 0)
            {
                list[s] = list[f];
                s = f;
                f = (s - 1) / 2;
            }

            list[s] = value;
        }
    }
}
