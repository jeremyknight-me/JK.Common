using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JK.Common.EntityFrameworkCore.SqlServer.Extensions;

public static class PropertyBuilderNumericExtensions
{
    public static PropertyBuilder<decimal> HasColumnTypeDecimal(this PropertyBuilder<decimal> propertyBuilder, int precision, int scale)
        => propertyBuilder.HasColumnType($"decimal({precision}, {scale})");

    public static PropertyBuilder<decimal?> HasColumnTypeDecimal(this PropertyBuilder<decimal?> propertyBuilder, int precision, int scale)
        => propertyBuilder.HasColumnType($"decimal({precision}, {scale})");

    public static PropertyBuilder<decimal> HasColumnTypeMoney(this PropertyBuilder<decimal> propertyBuilder)
        => propertyBuilder.HasColumnType("money");

    public static PropertyBuilder<decimal?> HasColumnTypeMoney(this PropertyBuilder<decimal?> propertyBuilder)
        => propertyBuilder.HasColumnType("money");
}
