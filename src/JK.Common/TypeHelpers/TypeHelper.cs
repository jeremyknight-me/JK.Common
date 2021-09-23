using System;

namespace JK.Common.TypeHelpers
{
    public static class TypeHelper
    {
        /// <summary>
        /// Determines whether or not a type uses <see cref="Nullable{T}"/>, aka T?
        /// </summary>
        /// <param name="type">The type to check</param>
        /// <returns>True if <see cref="Nullable{T}"/>, otherwise false</returns>
        public static bool IsNullable(Type type) => Nullable.GetUnderlyingType(type) != null;
        /// <summary>
        /// Determines whether or not a type uses <see cref="Nullable{T}"/>, aka T?
        /// </summary>
        /// <typeparam name="T">The type to check</typeparam>
        /// <returns>True if <see cref="Nullable{T}"/>, otherwise false</returns>
        public static bool IsNullable<T>() => IsNullable(typeof(T));
    }
}
