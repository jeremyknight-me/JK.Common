#if NET6_0_OR_GREATER

using System;

namespace JK.Common.EntityFrameworkCore.SqlServer.Extensions;

public static class ModelConfigurationBuilderExtensions
{
    public static void ApplyConventionPreferences(this ModelConfigurationBuilder configurationBuilder)
    {
        configurationBuilder.Properties<DateTime>().HaveColumnType("datetime2").HavePrecision(2);
        configurationBuilder.Properties<DateTimeOffset>().HavePrecision(2);
    }
}

#endif
