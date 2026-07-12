namespace JK.Common.Extensions;

/// <summary>
/// Helper and utility extension methods for <see cref="object"/>.
/// </summary>
public static class ObjectExtensions
{
    /// <summary>
    /// Determines whether the object is null.
    /// </summary>
    /// <param name="value">The value to check.</param>
    /// <returns><c>true</c> if the value is null; otherwise, <c>false</c>.</returns>
    public static bool IsNull(this object value) => value is null;

    /// <summary>
    /// Determines whether the object is not null.
    /// </summary>
    /// <param name="value">The value to check.</param>
    /// <returns><c>true</c> if the value is not null; otherwise, <c>false</c>.</returns>
    public static bool IsNotNull(this object value) => value is not null;
}
