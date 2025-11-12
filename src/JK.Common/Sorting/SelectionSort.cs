namespace JK.Common.Sorting;

/// <summary>
/// Provides an implementation of the selection sort algorithm.
/// </summary>
public static class SelectionSort
{
    /// <summary>
    /// Sorts the specified list in ascending order using the selection sort algorithm.
    /// </summary>
    /// <typeparam name="T">The type of elements in the list. Must implement <see cref="IComparable"/> and <see cref="IComparable{T}"/>.</typeparam>
    /// <param name="list">The list to sort.</param>
    public static void Sort<T>(IList<T> list) where T : IComparable, IComparable<T>
    {
        for (var i = 0; i <= list.Count - 2; i++)
        {
            for (var j = i + 1; j <= list.Count - 1; j++)
            {
                if (list[i].CompareTo(list[j]) > 0)
                {
                    (list[j], list[i]) = (list[i], list[j]);
                }
            }
        }
    }
}
