namespace JK.Common;

/// <summary>
/// Provides a facade for comparing objects of type <typeparamref name="T"/> for equality.
/// </summary>
/// <typeparam name="T">The type of objects to compare.</typeparam>
public sealed class EquatableFacade<T>
{
    /// <summary>
    /// Gets or sets the function used to determine equality between two objects of type <typeparamref name="T"/>
    /// .</summary>
    public Func<T, T, bool> AreObjectsEqual { get; set; } = (left, right) => left.Equals(right);

    /// <summary>
    /// Determines whether two objects are equal, using the <see cref="AreObjectsEqual"/> function if both are of type <typeparamref name="T"/>.
    /// </summary>
    /// <param name="left">The first object to compare.</param>
    /// <param name="right">The second object to compare.</param>
    /// <returns><c>true</c> if the objects are considered equal; otherwise, <c>false</c>.</returns>
    /// <exception cref="ArgumentException">Thrown if either argument is not of type <typeparamref name="T"/>.</exception>
    public bool AreEqual(object left, object right)
    {
        if (AreBothNull(left, right)
            || object.ReferenceEquals(left, right))
        {
            return true;
        }

        if (left is null || right is null)
        {
            return false;
        }

        if (left is not T)
        {
            throw new ArgumentException(@"The 'left' argument is not the correct type.", nameof(left));
        }

        if (right is not T)
        {
            throw new ArgumentException(@"The 'right' argument is not the correct type.", nameof(right));
        }

        return AreObjectsEqual((T)left, (T)right);
    }

    private static bool AreBothNull(object left, object right)
        => left is null && right is null;
}
