using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace JK.Common.EntityFrameworkCore.SqlServer.Extensions;

public static class PropertyBuilderExtensions
{
    public static PropertyBuilder<Guid> HasColumnTypeUniqueIdentifier(this PropertyBuilder<Guid> propertyBuilder)
        => propertyBuilder.HasColumnType("uniqueidentifier");

    public static PropertyBuilder<Guid?> HasColumnTypeUniqueIdentifier(this PropertyBuilder<Guid?> propertyBuilder)
        => propertyBuilder.HasColumnType("uniqueidentifier");
}
