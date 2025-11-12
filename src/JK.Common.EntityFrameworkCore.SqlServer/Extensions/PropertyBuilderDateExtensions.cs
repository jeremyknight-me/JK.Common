using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JK.Common.EntityFrameworkCore.SqlServer.Extensions;

public static class PropertyBuilderDateExtensions
{
    public static PropertyBuilder<DateTime> HasColumnTypeDateTime(this PropertyBuilder<DateTime> propertyBuilder)
        => propertyBuilder.HasColumnType("datetime");

    public static PropertyBuilder<DateTime?> HasColumnTypeDateTime(this PropertyBuilder<DateTime?> propertyBuilder)
        => propertyBuilder.HasColumnType("datetime");

    public static PropertyBuilder<DateTime> HasColumnTypeDateTime2(this PropertyBuilder<DateTime> propertyBuilder)
        => propertyBuilder.HasColumnType("datetime2");

    public static PropertyBuilder<DateTime?> HasColumnTypeDateTime2(this PropertyBuilder<DateTime?> propertyBuilder)
        => propertyBuilder.HasColumnType("datetime2");

    public static PropertyBuilder<DateTimeOffset> HasColumnTypeDateTimeOffset(this PropertyBuilder<DateTimeOffset> propertyBuilder)
        => propertyBuilder.HasColumnType("datetimeoffset");

    public static PropertyBuilder<DateTimeOffset?> HasColumnTypeDateTimeOffset(this PropertyBuilder<DateTimeOffset?> propertyBuilder)
        => propertyBuilder.HasColumnType("datetimeoffset");
}
