using System;
using System.Collections.Generic;

namespace JK.Common.Sorting;

public static class HeapSort
{
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
