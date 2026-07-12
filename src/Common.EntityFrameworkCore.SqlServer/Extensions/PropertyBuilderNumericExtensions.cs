using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JK.Common.EntityFrameworkCore.SqlServer.Extensions;

/// <summary>
/// Extension methods for configuring SQL Server numeric column types on <see cref="PropertyBuilder{TProperty}"/>.
/// </summary>
public static class PropertyBuilderNumericExtensions
{
    /// <summary>
    /// Configures the property to use the <c>decimal(precision, scale)</c> SQL Server column type.
    /// </summary>
    /// <param name="propertyBuilder">The property builder.</param>
    /// <param name="precision">The precision of the column.</param>
    /// <param name="scale">The scale of the column.</param>
    /// <returns>The property builder for chaining.</returns>
    public static PropertyBuilder<decimal> HasColumnTypeDecimal(this PropertyBuilder<decimal> propertyBuilder, int precision, int scale)
        => propertyBuilder.HasColumnType($"decimal({precision}, {scale})");

    /// <summary>
    /// Configures the property to use the <c>decimal(precision, scale)</c> SQL Server column type.
    /// </summary>
    /// <param name="propertyBuilder">The property builder.</param>
    /// <param name="precision">The precision of the column.</param>
    /// <param name="scale">The scale of the column.</param>
    /// <returns>The property builder for chaining.</returns>
    public static PropertyBuilder<decimal?> HasColumnTypeDecimal(this PropertyBuilder<decimal?> propertyBuilder, int precision, int scale)
        => propertyBuilder.HasColumnType($"decimal({precision}, {scale})");

    /// <summary>
    /// Configures the property to use the <c>money</c> SQL Server column type.
    /// </summary>
    /// <param name="propertyBuilder">The property builder.</param>
    /// <returns>The property builder for chaining.</returns>
    public static PropertyBuilder<decimal> HasColumnTypeMoney(this PropertyBuilder<decimal> propertyBuilder)
        => propertyBuilder.HasColumnType("money");

    /// <summary>
    /// Configures the property to use the <c>money</c> SQL Server column type.
    /// </summary>
    /// <param name="propertyBuilder">The property builder.</param>
    /// <returns>The property builder for chaining.</returns>
    public static PropertyBuilder<decimal?> HasColumnTypeMoney(this PropertyBuilder<decimal?> propertyBuilder)
        => propertyBuilder.HasColumnType("money");
}
