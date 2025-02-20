using System;

namespace JK.Common;

public sealed class EquatableFacade<T>
{
    public Func<T, T, bool> AreObjectsEqual { get; set; } = (left, right) => left.Equals(right);

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

        return this.AreObjectsEqual((T)left, (T)right);
    }

    private static bool AreBothNull(object left, object right)
        => left is null && right is null;
}
