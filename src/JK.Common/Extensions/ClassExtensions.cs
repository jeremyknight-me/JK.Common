namespace JK.Common.Extensions;

public static class ClassExtensions
{
    public static bool IsNull<T>(this T value) => value is null;

    public static bool IsNotNull<T>(this T value) => value is not null;
}
