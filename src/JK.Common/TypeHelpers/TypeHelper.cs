using System;

namespace JK.Common.TypeHelpers;

/// <summary>
/// Class which contains helper and utility methods for <see cref="Type"/>
/// </summary>
public static class TypeHelper
{
    /// <summary>
    /// Determines whether or not a type is nullable (including <see cref="Nullable{T}"/>, aka T?)
    /// </summary>
    /// <param name="type">The type to check</param>
    /// <returns>True if nullable, otherwise false</returns>
    public static bool IsNullable(in Type type)
        => !type.IsValueType || IsNullableT(type);

    /// <summary>
    /// Determines whether or not a type is nullable (including <see cref="Nullable{T}"/>, aka T?)
    /// </summary>
    /// <typeparam name="T">The type to check</typeparam>
    /// <returns>True if nullable, otherwise false</returns>
    public static bool IsNullable<T>()
        => IsNullable(typeof(T));

    /// <summary>
    /// Determines whether or not a type is nullable (including <see cref="Nullable{T}"/>, aka T?)
    /// </summary>
    /// <typeparam name="T">The type to check</typeparam>
    /// <param name="value">Value to get type from.</param>
    /// <returns>True if nullable, otherwise false</returns>
    public static bool IsNullable<T>(in T value)
        => value is null || IsNullable<T>();

    /// <summary>
    /// Determines whether or not a type uses <see cref="Nullable{T}"/>, aka T?
    /// </summary>
    /// <param name="type">The type to check</param>
    /// <returns>True if <see cref="Nullable{T}"/>, otherwise false</returns>
    public static bool IsNullableT(in Type type)
        => Nullable.GetUnderlyingType(type) != null;

    /// <summary>
    /// Determines whether or not a type uses <see cref="Nullable{T}"/>, aka T?
    /// </summary>
    /// <typeparam name="T">The type to check</typeparam>
    /// <returns>True if <see cref="Nullable{T}"/>, otherwise false</returns>
    public static bool IsNullableT<T>()
        => IsNullableT(typeof(T));
}
