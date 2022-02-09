namespace JK.Common.Sorting;

public class QuickSort
{
    public static void Sort(int[] arr, int low, int high)
    {
        if (low < high)
        {
            var partitionIndex = Partition(arr, low, high);
            Sort(arr, low, partitionIndex - 1);
            Sort(arr, partitionIndex + 1, high);
        }
    }

    private static int Partition(int[] arr, int low, int high)
    {
        var pivot = arr[low];
        while (high > low)
        {
            var highValue = arr[high];
            while (pivot < highValue)
            {
                if (high <= low)
                {
                    break;
                }
                high--;
                highValue = arr[high];
            }

            arr[low] = highValue;
            var lowValue = arr[low];
            while (pivot > lowValue)
            {
                if (high <= low)
                {
                    break;
                }
                low++;
                lowValue = arr[low];
            }

            arr[high] = lowValue;
        }

        arr[low] = pivot;
        return low;
    }
}
