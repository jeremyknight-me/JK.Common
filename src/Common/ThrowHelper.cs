namespace JK.Common;

/// <summary>
/// Provides helper methods for common argument validation and exception throwing.
/// </summary>
public static class ThrowHelper
{
    /// <summary>
    /// Throws an <see cref="ArgumentNullException"/> if the value is null.
    /// </summary>
    /// <param name="value">The value to validate.</param>
    /// <param name="paramName">The name of the parameter.</param>
    public static void IfNull(object value, string paramName)
    {
#if NET6_0_OR_GREATER
        ArgumentNullException.ThrowIfNull(value, paramName);
#else
        if (value is null)
        {
            throw new ArgumentNullException(paramName);
        }
#endif
    }

    /// <summary>
    /// Throws an <see cref="ArgumentException"/> if the value is null or empty.
    /// </summary>
    /// <param name="value">The value to validate.</param>
    /// <param name="paramName">The name of the parameter.</param>
    public static void IfNullOrEmpty(string value, string paramName)
    {
#if NET7_0_OR_GREATER
        ArgumentException.ThrowIfNullOrEmpty(value, paramName);
#else
        IfNull(value, paramName);
        if (string.IsNullOrEmpty(value))
        {
            throw new ArgumentException("The value cannot be an empty string.", paramName);
        }
#endif
    }

    /// <summary>
    /// Throws an <see cref="ArgumentException"/> if the value is null, empty, or whitespace.
    /// </summary>
    /// <param name="value">The value to validate.</param>
    /// <param name="paramName">The name of the parameter.</param>
    public static void IfNullOrWhiteSpace(string value, string paramName)
    {
#if NET8_0_OR_GREATER
        ArgumentException.ThrowIfNullOrWhiteSpace(value, paramName);
#else
        IfNull(value, paramName);
        if (string.IsNullOrWhiteSpace(value))
        {
            throw new ArgumentException("The value cannot be an empty string or consist only of white-space characters.", paramName);
        }
#endif
    }
}
