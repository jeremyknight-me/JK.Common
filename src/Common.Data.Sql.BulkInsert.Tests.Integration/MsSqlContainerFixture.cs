using System.Data.Common;
using Testcontainers.MsSql;
using Testcontainers.Xunit;
using Xunit.Sdk;

namespace JK.Common.Data.Sql.BulkInsert.Tests;

public sealed class MsSqlContainerFixture : DbContainerFixture<MsSqlBuilder, MsSqlContainer>
{
    public MsSqlContainerFixture(IMessageSink messageSink) 
        : base(messageSink)
    {
    }

    public override DbProviderFactory DbProviderFactory
        => SqlClientFactory.Instance;

    protected override MsSqlBuilder Configure()
        => new("mcr.microsoft.com/mssql/server:2022-CU14-ubuntu-22.04");

    protected override async ValueTask InitializeAsync()
    {
        await base.InitializeAsync();

        await using SqlConnection connection = (SqlConnection)await OpenConnectionAsync(TestContext.Current.CancellationToken);
        using SqlCommand command = connection.CreateCommand();
        command.CommandText = "CREATE TABLE Employees (FirstName NVARCHAR(100), LastName NVARCHAR(100), Age INT)";
        await command.ExecuteNonQueryAsync(TestContext.Current.CancellationToken);
    }

    protected override async ValueTask DisposeAsyncCore()
    {
        await using SqlConnection connection = (SqlConnection)await OpenConnectionAsync(TestContext.Current.CancellationToken);
        using SqlCommand command = connection.CreateCommand();
        command.CommandText = "DROP TABLE IF EXISTS Employees";
        await command.ExecuteNonQueryAsync(TestContext.Current.CancellationToken);

        await base.DisposeAsyncCore();
    }
}
