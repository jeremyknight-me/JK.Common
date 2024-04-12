using System;
using System.Linq;
using JK.Common.TypeHelpers;

namespace JK.Common.Extensions;

public static class TypeExtensions
{
    /// <summary>
    /// Determines whether or not a type implements the given interface.
    /// </summary>
    /// <typeparam name="T">Interface type to find.</typeparam>
    /// <param name="type">Type to check for the interface.</param>
    /// <returns>True if implemented, otherwise false.</returns>
    public static bool DoesImplement<T>(this Type type)
    {
        var interfaceType = typeof(T);
        return interfaceType.IsInterface
            ? type.GetInterfaces().Any(x => x.FullName == interfaceType.FullName)
            : throw new ArgumentException("Only interfaces can be passed as T.");
    }

    /// <summary>
    /// Attempts to get the underlying <see cref="Type"/> from an Entity Framework proxied type.
    /// </summary>
    /// <param name="type">Suspected DynamicProxy type.</param>
    /// <returns>Underlying entity <see cref="Type"/>.</returns>
    public static Type GetTypeFromEntity(this Type type)
    {
        if (type.BaseType is not null && type.Namespace == "System.Data.Entity.DynamicProxies")
        {
            type = type.BaseType;
        }
        return type;
    }

    /// <summary>
    /// Determines whether or not a type is nullable (including <see cref="Nullable{T}"/>, aka T?)
    /// </summary>
    /// <param name="type">The type to check</param>
    /// <returns>True if nullable, otherwise false</returns>
    public static bool IsNullable(this Type type) => TypeHelper.IsNullable(type);

    /// <summary>
    /// Determines whether or not a type uses <see cref="Nullable{T}"/>, aka T?
    /// </summary>
    /// <param name="type">The type to check</param>
    /// <returns>True if <see cref="Nullable{T}"/>, otherwise false</returns>
    public static bool IsNullableT(this Type type) => TypeHelper.IsNullableT(type);
}
