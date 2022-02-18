using System;
using System.Collections.Generic;

namespace JK.Common.Sorting
{
    public static class BubbleSort
    {
        public static void Sort<T>(IList<T> data) where T : IComparable, IComparable<T>
        {
            for (var a = 1; a < data.Count; a++)
            {
                for (var b = data.Count - 1; b >= a; b--)
                {
                    if (data[b].CompareTo(data[b - 1]) < 0)
                    {
                        var t = data[b - 1];
                        data[b - 1] = data[b];
                        data[b] = t;
                    }
                }
            }
        }
    }
}
