namespace JK.Common.Sorting;

/// <summary>
/// Provides a static implementation of the insertion sort algorithm.
/// </summary>
public static class InsertionSort
{
    /// <summary>
    /// Sorts the specified list in ascending order using the insertion sort algorithm.
    /// </summary>
    /// <typeparam name="T">The type of elements in the list. Must implement <see cref="IComparable"/> and <see cref="IComparable{T}"/>.</typeparam>
    /// <param name="list">The list to sort.</param>
    public static void Sort<T>(IList<T> list) where T : IComparable, IComparable<T>
    {
        for (var i = 0; i < list.Count - 1; i++)
        {
            for (var j = i + 1; j > 0; j--)
            {
                if (list[j - 1].CompareTo(list[j]) > 0)
                {
                    (list[j], list[j - 1]) = (list[j - 1], list[j]);
                }
            }
        }
    }
}
