namespace JK.Common.Sorting
{
    public static class MergeSort
    {
        public static void Sort(int[] list)
            => Sort(list, 0, list.Length - 1);

        public static void Sort(int[] list, int low, int high)
        {
            if (low < high)
            {
                var mid = (low + high) / 2;
                Sort(list, low, mid);
                Sort(list, mid + 1, high);
                Merge(list, low, mid, high);
            }
        }

        private static void Merge(int[] list, int low, int mid, int high)
        {
            var h = low;
            var i = low;
            var j = mid + 1;
            var temp = new int[list.Length];
            while (h <= mid && j <= high)
            {
                if (list[h] <= list[j])
                {
                    temp[i] = list[h];
                    h++;
                }
                else
                {
                    temp[i] = list[j];
                    j++;
                }
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
