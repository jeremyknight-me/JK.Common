﻿using System;
using System.Collections.Generic;

namespace JK.Common.Sorting
{
    public static class MergeSort
    {
        public static void Sort<T>(IList<T> list) where T : IComparable, IComparable<T>
            => Sort(list, 0, list.Count - 1);

        private static void Sort<T>(IList<T> list, int low, int high)
            where T : IComparable, IComparable<T>
        {
            if (low < high)
            {
                var mid = (low + high) / 2;
                Sort(list, low, mid);
                Sort(list, mid + 1, high);
                Merge(list, low, mid, high);
            }
        }

        private static void Merge<T>(IList<T> list, int low, int mid, int high)
            where T : IComparable, IComparable<T>
        {
            var h = low;
            var i = low;
            var j = mid + 1;
            var temp = new List<T>(new T[list.Count]);
            while (h <= mid && j <= high)
            {
                temp[i] = list[h].CompareTo(list[j]) <= 0
                    ? list[h++]
                    : list[j++];
                i++;
            }

            if (h > mid)
            {
                for (var k = j; k <= high; k++)
                {
                    temp[i] = list[k];
                    i++;
                }
            }
            else
            {
                for (var k = h; k <= mid; k++)
                {
                    temp[i] = list[k];
                    i++;
                }
            }

            for (var k = low; k <= high; k++)
            {
                list[k] = temp[k];
            }
        }
    }
}
