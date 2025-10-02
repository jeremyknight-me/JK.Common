namespace JK.Common.Extensions;

/// <summary>
/// Helper and utility extension methods for <see cref="object"/>.
/// </summary>
public static class ObjectExtensions
{
    /// <summary>
    /// Determines whether the specified value is null.
    /// </summary>
    /// <typeparam name="T">The type of the value.</typeparam>
    /// <param name="value">The value to check.</param>
    /// <returns><c>true</c> if the value is null; otherwise, <c>false</c>.</returns>
    public static bool IsNull<T>(this T value) => value is null;

    /// <summary>
    /// Determines whether the specified value is not null.
    /// </summary>
    /// <typeparam name="T">The type of the value.</typeparam>
    /// <param name="value">The value to check.</param>
    /// <returns><c>true</c> if the value is not null; otherwise, <c>false</c>.</returns>
    public static bool IsNotNull<T>(this T value) => value is not null;
}
