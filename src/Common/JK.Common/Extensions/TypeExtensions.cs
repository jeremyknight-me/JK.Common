using System;
using System.Linq;

namespace JK.Common.Extensions
{
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
            if (!interfaceType.IsInterface)
            {
                throw new ArgumentException("Only interfaces can be passed as T.");
            }

            return type.GetInterfaces().Any(x => x.FullName == interfaceType.FullName); ;
        }

        public static Type GetTypeFromEntity(this Type type)
        {
            if (type.BaseType != null && type.Namespace == "System.Data.Entity.DynamicProxies")
            {
                type = type.BaseType;
            }
            return type;
        }
    }
}
