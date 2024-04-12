namespace JK.Common.Extensions;

/// <summary>
/// Helper and utility extension methods for <see cref="object"/>.
/// </summary>
public static class ObjectExtensions
{
    public static bool IsNull<T>(this T value) => value is null;

    public static bool IsNotNull<T>(this T value) => value is not null;
}
