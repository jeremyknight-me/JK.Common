using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JK.Common.EntityFrameworkCore.SqlServer.Extensions
{
    public static class PropertyBuilderExtensions
    {
        public static PropertyBuilder<TProperty> HasColumnTypeDateTime<TProperty>(this PropertyBuilder<TProperty> propertyBuilder)
        {
            return propertyBuilder.HasColumnType("datetime");
        }

        public static PropertyBuilder<TProperty> HasDateTime2ColumnType<TProperty>(this PropertyBuilder<TProperty> propertyBuilder)
        {
            return propertyBuilder.HasColumnType("datetime2");
        }

        public static PropertyBuilder<TProperty> HasColumnTypeDecimal<TProperty>(this PropertyBuilder<TProperty> propertyBuilder, int precision, int scale)
        {
            return propertyBuilder.HasColumnType($"decimal({precision}, {scale})");
        }

        public static PropertyBuilder<TProperty> HasColumnTypeMoney<TProperty>(this PropertyBuilder<TProperty> propertyBuilder)
        {
            return propertyBuilder.HasColumnType("money");
        }

        public static PropertyBuilder<TProperty> HasColumnTypeNvarchar<TProperty>(this PropertyBuilder<TProperty> propertyBuilder, int length)
        {
            return propertyBuilder.HasColumnType($"nvarchar({length})");
        }

        public static PropertyBuilder<TProperty> HasColumnTypeUniqueIdentifier<TProperty>(this PropertyBuilder<TProperty> propertyBuilder)
        {
            return propertyBuilder.HasColumnType("uniqueidentifier");
        }

        public static PropertyBuilder<TProperty> HasVarcharColumnType<TProperty>(this PropertyBuilder<TProperty> propertyBuilder, int length)
        {
            return propertyBuilder.HasColumnType($"varchar({length})");
        }
    }
}
