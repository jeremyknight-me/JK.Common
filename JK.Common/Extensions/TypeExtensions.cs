using System;

namespace JK.Common.Extensions
{
    public static class TypeExtensions
    {
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
