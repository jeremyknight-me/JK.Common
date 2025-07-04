using System;
using System.Collections.Generic;

namespace JK.Common.Sorting;

public static class SelectionSort
{
    public static void Sort<T>(IList<T> list) where T : IComparable, IComparable<T>
    {
        for (var i = 0; i <= list.Count - 2; i++)
        {
            for (var j = i + 1; j <= list.Count - 1; j++)
            {
                if (list[i].CompareTo(list[j]) > 0)
                {
                    T temp = list[i];
                    list[i] = list[j];
                    list[j] = temp;
                }
            }
        }
    }
}
