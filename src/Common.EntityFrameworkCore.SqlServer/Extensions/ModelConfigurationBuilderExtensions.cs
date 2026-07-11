namespace JK.Common.EntityFrameworkCore.SqlServer.Extensions;

public static class ModelConfigurationBuilderExtensions
{
    public static void ApplyConventionPreferences(this ModelConfigurationBuilder configurationBuilder)
    {
        configurationBuilder.Properties<DateTime>().HaveColumnType("datetime2").HavePrecision(2);
        configurationBuilder.Properties<DateTimeOffset>().HavePrecision(2);
        configurationBuilder.Properties<decimal>().HavePrecision(19, 5);
        configurationBuilder.Properties<string>().AreUnicode();
    }
}
