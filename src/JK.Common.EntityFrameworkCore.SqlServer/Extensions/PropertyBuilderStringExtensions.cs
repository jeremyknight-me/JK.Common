using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JK.Common.EntityFrameworkCore.SqlServer.Extensions;

public static class PropertyBuilderStringExtensions
{
    public static PropertyBuilder<string> HasColumnTypeNvarchar(this PropertyBuilder<string> propertyBuilder)
        => propertyBuilder.HasColumnType("nvarchar(max)");

    public static PropertyBuilder<string> HasColumnTypeNvarchar(this PropertyBuilder<string> propertyBuilder, int length)
        => propertyBuilder.HasColumnType($"nvarchar({length})");

    public static PropertyBuilder<string> HasColumnTypeVarchar(this PropertyBuilder<string> propertyBuilder)
        => propertyBuilder.HasColumnType("varchar(max)");

    public static PropertyBuilder<string> HasColumnTypeVarchar(this PropertyBuilder<string> propertyBuilder, int length)
        => propertyBuilder.HasColumnType($"varchar({length})");
}
