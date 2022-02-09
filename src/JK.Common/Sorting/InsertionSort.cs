using System;
using System.Collections.Generic;

namespace JK.Common.Sorting;

public static class InsertionSort
{
    public static void Sort<T>(IList<T> list) where T : IComparable, IComparable<T>
    {
        for (var i = 0; i < list.Count - 1; i++)
        {
            for (var j = i + 1; j > 0; j--)
            {
                if (list[j - 1].CompareTo(list[j]) > 0)
                {
                    var temp = list[j - 1];
                    list[j - 1] = list[j];
                    list[j] = temp;
                }
            }
        }
    }
}
