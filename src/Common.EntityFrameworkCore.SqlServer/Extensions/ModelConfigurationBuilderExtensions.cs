namespace JK.Common.EntityFrameworkCore.SqlServer.Extensions;

/// <summary>
/// Extension methods for <see cref="ModelConfigurationBuilder"/>.
/// </summary>
public static class ModelConfigurationBuilderExtensions
{
    /// <summary>
    /// Applies default convention preferences for SQL Server column types and precision.
    /// </summary>
    /// <param name="configurationBuilder">The model configuration builder.</param>
    public static void ApplyConventionPreferences(this ModelConfigurationBuilder configurationBuilder)
    {
        configurationBuilder.Properties<DateTime>().HaveColumnType("datetime2").HavePrecision(2);
        configurationBuilder.Properties<DateTimeOffset>().HavePrecision(2);
        configurationBuilder.Properties<decimal>().HavePrecision(19, 5);
        configurationBuilder.Properties<string>().AreUnicode();
    }
}
