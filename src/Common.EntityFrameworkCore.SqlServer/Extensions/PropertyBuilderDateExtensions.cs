using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JK.Common.EntityFrameworkCore.SqlServer.Extensions;

/// <summary>
/// Extension methods for configuring SQL Server date and time column types on <see cref="PropertyBuilder{TProperty}"/>.
/// </summary>
public static class PropertyBuilderDateExtensions
{
    /// <summary>
    /// Configures the property to use the <c>datetime</c> SQL Server column type.
    /// </summary>
    /// <param name="propertyBuilder">The property builder.</param>
    /// <returns>The property builder for chaining.</returns>
    public static PropertyBuilder<DateTime> HasColumnTypeDateTime(this PropertyBuilder<DateTime> propertyBuilder)
        => propertyBuilder.HasColumnType("datetime");

    /// <summary>
    /// Configures the property to use the <c>datetime</c> SQL Server column type.
    /// </summary>
    /// <param name="propertyBuilder">The property builder.</param>
    /// <returns>The property builder for chaining.</returns>
    public static PropertyBuilder<DateTime?> HasColumnTypeDateTime(this PropertyBuilder<DateTime?> propertyBuilder)
        => propertyBuilder.HasColumnType("datetime");

    /// <summary>
    /// Configures the property to use the <c>datetime2</c> SQL Server column type.
    /// </summary>
    /// <param name="propertyBuilder">The property builder.</param>
    /// <returns>The property builder for chaining.</returns>
    public static PropertyBuilder<DateTime> HasColumnTypeDateTime2(this PropertyBuilder<DateTime> propertyBuilder)
        => propertyBuilder.HasColumnType("datetime2");

    /// <summary>
    /// Configures the property to use the <c>datetime2</c> SQL Server column type.
    /// </summary>
    /// <param name="propertyBuilder">The property builder.</param>
    /// <returns>The property builder for chaining.</returns>
    public static PropertyBuilder<DateTime?> HasColumnTypeDateTime2(this PropertyBuilder<DateTime?> propertyBuilder)
        => propertyBuilder.HasColumnType("datetime2");

    /// <summary>
    /// Configures the property to use the <c>datetimeoffset</c> SQL Server column type.
    /// </summary>
    /// <param name="propertyBuilder">The property builder.</param>
    /// <returns>The property builder for chaining.</returns>
    public static PropertyBuilder<DateTimeOffset> HasColumnTypeDateTimeOffset(this PropertyBuilder<DateTimeOffset> propertyBuilder)
        => propertyBuilder.HasColumnType("datetimeoffset");

    /// <summary>
    /// Configures the property to use the <c>datetimeoffset</c> SQL Server column type.
    /// </summary>
    /// <param name="propertyBuilder">The property builder.</param>
    /// <returns>The property builder for chaining.</returns>
    public static PropertyBuilder<DateTimeOffset?> HasColumnTypeDateTimeOffset(this PropertyBuilder<DateTimeOffset?> propertyBuilder)
        => propertyBuilder.HasColumnType("datetimeoffset");
}
