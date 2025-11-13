namespace JK.Common.Extensions;

/// <summary>
/// Helper and utility extension methods for <see cref="HashSet{T}"/>.
/// </summary>
public static class HashSetExtensions
{
    extension<T>(HashSet<T> set)
    {
        /// <summary>
        /// Adds a range of values to the <see cref="HashSet{T}"/>.
        /// </summary>
        /// <param name="items">The values to add to the set.</param>
        public void AddRange(IEnumerable<T> items)
        {
            if (items is null)
            {
                return;
            }

            foreach (T value in items)
            {
                _ = set.Add(value);
            }
        }

        /// <summary>
        /// Adds a range of values to the <see cref="HashSet{T}"/> only if each value is not <c>null</c>.
        /// </summary>
        /// <param name="items">The values to add to the set. Null values are ignored.</param>
        /// <remarks>
        /// This method iterates through the provided <paramref name="items"/> and adds each non-null value to the set.
        /// </remarks>
        public void AddRangeIfNotNull(IEnumerable<T> items)
        {
            if (items is null)
            {
                return;
            }

            foreach (T value in items)
            {
                _ = set.AddIfNotNull(value);
            }
        }

        /// <summary>
        /// Adds the specified value to the <see cref="HashSet{T}"/> if it is not <c>null</c>.
        /// </summary>
        /// <param name="value">The value to add to the set. If <c>null</c>, the value is ignored.</param>
        /// <returns>
        /// <c>true</c> if the value was added to the set; <c>false</c> if the value was <c>null</c> or already present.
        /// </returns>
        public bool AddIfNotNull(T value)
            => value is not null && set.Add(value);
    }
}
