namespace JK.Common.Sorting;

/// <summary>
/// Provides an implementation of the bubble sort algorithm.
/// </summary>
public static class BubbleSort
{
    /// <summary>
    /// Sorts the specified list in ascending order using the bubble sort algorithm.
    /// </summary>
    /// <typeparam name="T">The type of elements in the list. Must implement <see cref="IComparable"/> and <see cref="IComparable{T}"/>.</typeparam>
    /// <param name="data">The list to sort.</param>
    public static void Sort<T>(IList<T> data) where T : IComparable, IComparable<T>
    {
        for (var a = 1; a < data.Count; a++)
        {
            for (var b = data.Count - 1; b >= a; b--)
            {
                if (data[b].CompareTo(data[b - 1]) < 0)
                {
                    (data[b], data[b - 1]) = (data[b - 1], data[b]);
                }
            }
        }
    }
}
