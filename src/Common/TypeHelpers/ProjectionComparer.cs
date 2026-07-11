namespace JK.Common.TypeHelpers;

/// <summary>
/// Provides an <see cref="IEqualityComparer{T}"/> implementation that compares objects by a projected value.
/// </summary>
/// <typeparam name="TSource">The type of objects to compare.</typeparam>
public static class ProjectionComparer<TSource>
{
    /// <summary>
    /// Creates an <see cref="IEqualityComparer{T}"/> that compares objects by the value returned by the specified selector.
    /// </summary>
    /// <typeparam name="TValue">The type of the projected value.</typeparam>
    /// <param name="selector">The projection function used to extract the comparison value.</param>
    /// <returns>An <see cref="IEqualityComparer{T}"/> that compares objects by the projected value.</returns>
    public static IEqualityComparer<TSource> CompareBy<TValue>(Func<TSource, TValue> selector)
        => CompareBy(selector, EqualityComparer<TValue>.Default);

    /// <summary>
    /// Creates an <see cref="IEqualityComparer{T}"/> that compares objects by the value returned by the specified selector, using the specified comparer.
    /// </summary>
    /// <typeparam name="TValue">The type of the projected value.</typeparam>
    /// <param name="selector">The projection function used to extract the comparison value.</param>
    /// <param name="comparer">The <see cref="IEqualityComparer{T}"/> used to compare projected values.</param>
    /// <returns>An <see cref="IEqualityComparer{T}"/> that compares objects by the projected value.</returns>
    public static IEqualityComparer<TSource> CompareBy<TValue>(Func<TSource, TValue> selector, IEqualityComparer<TValue> comparer)
        => new ComparerImpl<TValue>(selector, comparer);

    private sealed class ComparerImpl<TValue> : IEqualityComparer<TSource>
    {
        private readonly Func<TSource, TValue> _selector;
        private readonly IEqualityComparer<TValue> _comparer;

        public ComparerImpl(Func<TSource, TValue> selectorFunction, IEqualityComparer<TValue> equalityComparer)
        {
            if (selectorFunction is null)
            {
                throw new ArgumentNullException(nameof(selectorFunction));
            }

            if (equalityComparer is null)
            {
                throw new ArgumentNullException(nameof(equalityComparer));
            }

            _selector = selectorFunction;
            _comparer = equalityComparer;
        }

        bool IEqualityComparer<TSource>.Equals(TSource x, TSource y)
        {
            if (x.Equals(default(TSource)) && y.Equals(default(TSource)))
            {
                return true;
            }

            if (x.Equals(default(TSource)) || y.Equals(default(TSource)))
            {
                return false;
            }

            return _comparer.Equals(_selector(x), _selector(y));
        }

        int IEqualityComparer<TSource>.GetHashCode(TSource obj)
            => obj.Equals(default(TSource)) ? 0 : _comparer.GetHashCode(_selector(obj));
    }
}
