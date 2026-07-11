using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JK.Common.EntityFrameworkCore.SqlServer.Extensions;

/// <summary>
/// Extension methods for configuring SQL Server column types on <see cref="PropertyBuilder{TProperty}"/>.
/// </summary>
public static class PropertyBuilderExtensions
{
    /// <summary>
    /// Configures the property to use the <c>uniqueidentifier</c> SQL Server column type.
    /// </summary>
    /// <param name="propertyBuilder">The property builder.</param>
    /// <returns>The property builder for chaining.</returns>
    public static PropertyBuilder<Guid> HasColumnTypeUniqueIdentifier(this PropertyBuilder<Guid> propertyBuilder)
        => propertyBuilder.HasColumnType("uniqueidentifier");

    /// <summary>
    /// Configures the property to use the <c>uniqueidentifier</c> SQL Server column type.
    /// </summary>
    /// <param name="propertyBuilder">The property builder.</param>
    /// <returns>The property builder for chaining.</returns>
    public static PropertyBuilder<Guid?> HasColumnTypeUniqueIdentifier(this PropertyBuilder<Guid?> propertyBuilder)
        => propertyBuilder.HasColumnType("uniqueidentifier");
}
