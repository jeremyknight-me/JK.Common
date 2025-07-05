using System;
using System.Collections.Generic;

namespace JK.Common.Sorting;

public static class QuickSort
{
    public static void Sort<T>(IList<T> list) where T : IComparable, IComparable<T>
        => Sort(list, 0, list.Count - 1);

    private static void Sort<T>(IList<T> list, int low, int high)
        where T : IComparable, IComparable<T>
    {
        if (low < high)
        {
            var partitionIndex = Partition(list, low, high);
            Sort(list, low, partitionIndex - 1);
            Sort(list, partitionIndex + 1, high);
        }
    }

    private static int Partition<T>(IList<T> list, int low, int high)
        where T : IComparable, IComparable<T>
    {
        T pivot = list[low];
        while (high > low)
        {
            T highValue = list[high];
            while (pivot.CompareTo(highValue) < 0)
            {
                if (high <= low)
                {
                    break;
                }

                high--;
                highValue = list[high];
            }

            list[low] = highValue;
            T lowValue = list[low];
            while (pivot.CompareTo(lowValue) > 0)
            {
                if (high <= low)
                {
                    break;
                }

                low++;
                lowValue = list[low];
            }

            list[high] = lowValue;
        }

        list[low] = pivot;
        return low;
    }
}
