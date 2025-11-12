using System.Linq;

namespace JK.Common.Extensions;

/// <summary>
/// Helper and utility extension methods for <see cref="Type"/>.
/// </summary>
public static class TypeExtensions
{
    extension(Type type)
    {
        /// <summary>
        /// Determines whether or not a type implements the given interface.
        /// </summary>
        /// <typeparam name="T">Interface type to find.</typeparam>
        /// <returns>True if implemented, otherwise false.</returns>
        public bool DoesImplement<T>()
        {
            Type interfaceType = typeof(T);
            return interfaceType.IsInterface
                ? type.GetInterfaces().Any(x => x.FullName == interfaceType.FullName)
                : throw new ArgumentException("Only interfaces can be passed as T.");
        }

        /// <summary>
        /// Attempts to get the underlying <see cref="Type"/> from an Entity Framework proxied type.
        /// </summary>
        /// <returns>Underlying entity <see cref="Type"/>.</returns>
        public Type GetTypeFromEntity()
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
        /// <returns>True if nullable, otherwise false</returns>
        public bool IsNullable()
            => !type.IsValueType || IsNullableT(type);

        /// <summary>
        /// Determines whether or not a type is nullable (including <see cref="Nullable{T}"/>, aka T?)
        /// </summary>
        /// <typeparam name="T">The type to check</typeparam>
        /// <returns>True if nullable, otherwise false</returns>
        public bool IsNullable<T>()
            => type is null || typeof(T).IsNullable();

        /// <summary>
        /// Determines whether the specified type is a nullable value type (i.e., Nullable&lt;T&gt;).
        /// </summary>
        /// <returns>True if the type is a nullable value type; otherwise, false.</returns>
        public bool IsNullableT()
            => Nullable.GetUnderlyingType(type) != null;
    }
}
