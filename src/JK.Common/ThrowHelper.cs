namespace JK.Common;

public static class ThrowHelper
{
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

    public static void IfNullOrEmpty(string value, string paramName)
    {
#if NET7_0_OR_GREATER
        ArgumentException.ThrowIfNullOrEmpty(value, paramName);
#else
        if (string.IsNullOrEmpty(value))
        {
            throw new ArgumentNullException(paramName);
        }
#endif
    }

    public static void IfNullOrWhiteSpace(string value, string paramName)
    {
#if NET8_0_OR_GREATER
        ArgumentException.ThrowIfNullOrWhiteSpace(value, paramName);
#else
        if (string.IsNullOrWhiteSpace(value))
        {
            throw new ArgumentNullException(paramName);
        }
#endif
    }
}
