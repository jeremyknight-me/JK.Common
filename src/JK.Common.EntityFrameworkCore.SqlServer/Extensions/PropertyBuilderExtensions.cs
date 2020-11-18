using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace JK.Common.EntityFrameworkCore.SqlServer.Extensions
{
    public static class PropertyBuilderExtensions
    {
        public static PropertyBuilder<Guid> HasColumnTypeUniqueIdentifier(this PropertyBuilder<Guid> propertyBuilder)
        {
            return propertyBuilder.HasColumnType("uniqueidentifier");
        }

        public static PropertyBuilder<Guid?> HasColumnTypeUniqueIdentifier(this PropertyBuilder<Guid?> propertyBuilder)
        {
            return propertyBuilder.HasColumnType("uniqueidentifier");
        }

        #region Date Data Types

        public static PropertyBuilder<DateTime> HasColumnTypeDateTime(this PropertyBuilder<DateTime> propertyBuilder)
        {
            return propertyBuilder.HasColumnType("datetime");
        }

        public static PropertyBuilder<DateTime?> HasColumnTypeDateTime(this PropertyBuilder<DateTime?> propertyBuilder)
        {
            return propertyBuilder.HasColumnType("datetime");
        }

        public static PropertyBuilder<DateTime> HasColumnTypeDateTime2(this PropertyBuilder<DateTime> propertyBuilder)
        {
            return propertyBuilder.HasColumnType("datetime2");
        }

        public static PropertyBuilder<DateTime?> HasColumnTypeDateTime2(this PropertyBuilder<DateTime?> propertyBuilder)
        {
            return propertyBuilder.HasColumnType("datetime2");
        }

        public static PropertyBuilder<DateTimeOffset> HasColumnTypeDateTimeOffset(this PropertyBuilder<DateTimeOffset> propertyBuilder)
        {
            return propertyBuilder.HasColumnType("datetimeoffset");
        }

        public static PropertyBuilder<DateTimeOffset?> HasColumnTypeDateTimeOffset(this PropertyBuilder<DateTimeOffset?> propertyBuilder)
        {
            return propertyBuilder.HasColumnType("datetimeoffset");
        }

        #endregion

        #region Numeric Data Types

        public static PropertyBuilder<decimal> HasColumnTypeDecimal(this PropertyBuilder<decimal> propertyBuilder, int precision, int scale)
        {
            return propertyBuilder.HasColumnType($"decimal({precision}, {scale})");
        }

        public static PropertyBuilder<decimal?> HasColumnTypeDecimal(this PropertyBuilder<decimal?> propertyBuilder, int precision, int scale)
        {
            return propertyBuilder.HasColumnType($"decimal({precision}, {scale})");
        }

        public static PropertyBuilder<decimal> HasColumnTypeMoney(this PropertyBuilder<decimal> propertyBuilder)
        {
            return propertyBuilder.HasColumnType("money");
        }

        public static PropertyBuilder<decimal?> HasColumnTypeMoney(this PropertyBuilder<decimal?> propertyBuilder)
        {
            return propertyBuilder.HasColumnType("money");
        }

        #endregion

        #region String Data Types

        public static PropertyBuilder<string> HasColumnTypeNvarchar(this PropertyBuilder<string> propertyBuilder)
        {
            return propertyBuilder.HasColumnType("nvarchar(max)");
        }

        public static PropertyBuilder<string> HasColumnTypeNvarchar(this PropertyBuilder<string> propertyBuilder, int length)
        {
            return propertyBuilder.HasColumnType($"nvarchar({length})");
        }

        public static PropertyBuilder<string> HasColumnTypeVarchar(this PropertyBuilder<string> propertyBuilder)
        {
            return propertyBuilder.HasColumnType("varchar(max)");
        }

        public static PropertyBuilder<string> HasColumnTypeVarchar(this PropertyBuilder<string> propertyBuilder, int length)
        {
            return propertyBuilder.HasColumnType($"varchar({length})");
        }

        #endregion
    }
}
