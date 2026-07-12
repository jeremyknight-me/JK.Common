using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JK.Common.EntityFrameworkCore.SqlServer.Extensions;

/// <summary>
/// Extension methods for configuring SQL Server string column types on <see cref="PropertyBuilder{TProperty}"/>.
/// </summary>
public static class PropertyBuilderStringExtensions
{
    /// <summary>
    /// Configures the property to use the <c>nvarchar(max)</c> SQL Server column type.
    /// </summary>
    /// <param name="propertyBuilder">The property builder.</param>
    /// <returns>The property builder for chaining.</returns>
    public static PropertyBuilder<string> HasColumnTypeNvarchar(this PropertyBuilder<string> propertyBuilder)
        => propertyBuilder.HasColumnType("nvarchar(max)").IsUnicode();

    /// <summary>
    /// Configures the property to use the <c>nvarchar(length)</c> SQL Server column type.
    /// </summary>
    /// <param name="propertyBuilder">The property builder.</param>
    /// <param name="length">The maximum length of the column.</param>
    /// <returns>The property builder for chaining.</returns>
    public static PropertyBuilder<string> HasColumnTypeNvarchar(this PropertyBuilder<string> propertyBuilder, int length)
        => propertyBuilder.HasColumnType($"nvarchar({length})").HasMaxLength(length).IsUnicode();

    /// <summary>
    /// Configures the property to use the <c>varchar(max)</c> SQL Server column type.
    /// </summary>
    /// <param name="propertyBuilder">The property builder.</param>
    /// <returns>The property builder for chaining.</returns>
    public static PropertyBuilder<string> HasColumnTypeVarchar(this PropertyBuilder<string> propertyBuilder)
        => propertyBuilder.HasColumnType("varchar(max)").IsUnicode(false);

    /// <summary>
    /// Configures the property to use the <c>varchar(length)</c> SQL Server column type.
    /// </summary>
    /// <param name="propertyBuilder">The property builder.</param>
    /// <param name="length">The maximum length of the column.</param>
    /// <returns>The property builder for chaining.</returns>
    public static PropertyBuilder<string> HasColumnTypeVarchar(this PropertyBuilder<string> propertyBuilder, int length)
        => propertyBuilder.HasColumnType($"varchar({length})").HasMaxLength(length).IsUnicode(false);
}
