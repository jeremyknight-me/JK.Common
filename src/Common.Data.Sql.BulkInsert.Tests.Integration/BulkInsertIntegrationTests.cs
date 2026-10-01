using System.Data;

namespace JK.Common.Data.Sql.BulkInsert.Tests;

[Collection("Sequential")]
public class BulkInsertIntegrationTests : IClassFixture<MsSqlContainerFixture>, IAsyncLifetime
{
    private readonly MsSqlContainerFixture _fixture;

    public BulkInsertIntegrationTests(MsSqlContainerFixture fixture)
    {
        _fixture = fixture;
    }

    public async ValueTask InitializeAsync()
    {
        await using SqlConnection connection = (SqlConnection)await _fixture.OpenConnectionAsync(TestContext.Current.CancellationToken);
        using SqlCommand command = connection.CreateCommand();
        command.CommandText = "TRUNCATE TABLE Employees";
        await command.ExecuteNonQueryAsync(TestContext.Current.CancellationToken);
    }

    public ValueTask DisposeAsync() => default;

    private async Task<SqlConnection> CreateOpenConnectionAsync()
        => (SqlConnection)await _fixture.OpenConnectionAsync(TestContext.Current.CancellationToken);

    [Fact]
    public async Task Execute_InsertsAllRows()
    {
        List<SampleType> items =
        [
            new() { FirstName = "John", LastName = "Doe", Age = 30 },
            new() { FirstName = "Jane", LastName = "Smith", Age = 25 }
        ];

        using SqlConnection connection = await CreateOpenConnectionAsync();
        SampleTypeBulkInserter.Execute(connection, items);

        using SqlCommand command = connection.CreateCommand();
        command.CommandText = "SELECT COUNT(*) FROM Employees";
        int count = Convert.ToInt32(await command.ExecuteScalarAsync(TestContext.Current.CancellationToken));
        Assert.Equal(2, count);
    }

    [Fact]
    public async Task ExecuteAsync_InsertsAllRows()
    {
        List<SampleType> items =
        [
            new() { FirstName = "John", LastName = "Doe", Age = 30 },
            new() { FirstName = "Jane", LastName = "Smith", Age = 25 }
        ];

        using SqlConnection connection = await CreateOpenConnectionAsync();
        await SampleTypeBulkInserter.ExecuteAsync(connection, items, cancellationToken: TestContext.Current.CancellationToken);

        using SqlCommand command = connection.CreateCommand();
        command.CommandText = "SELECT COUNT(*) FROM Employees";
        int count = Convert.ToInt32(await command.ExecuteScalarAsync(TestContext.Current.CancellationToken));
        Assert.Equal(2, count);
    }

    [Fact]
    public async Task ExecuteAsync_VerifiesInsertedValues()
    {
        List<SampleType> items =
        [
            new() { FirstName = "John", LastName = "Doe", Age = 30 }
        ];

        using SqlConnection connection = await CreateOpenConnectionAsync();
        await SampleTypeBulkInserter.ExecuteAsync(connection, items, cancellationToken: TestContext.Current.CancellationToken);

        using SqlCommand command = connection.CreateCommand();
        command.CommandText = "SELECT FirstName, LastName, Age FROM Employees";
        using SqlDataReader reader = await command.ExecuteReaderAsync(TestContext.Current.CancellationToken);
        Assert.True(await reader.ReadAsync(TestContext.Current.CancellationToken));
        Assert.Equal("John", reader.GetString(0));
        Assert.Equal("Doe", reader.GetString(1));
        Assert.Equal(30, reader.GetInt32(2));
        Assert.False(await reader.ReadAsync(TestContext.Current.CancellationToken));
    }

    [Fact]
    public async Task ExecuteAsync_EmptyList_InsertsNoRows()
    {
        List<SampleType> items = [];

        using SqlConnection connection = await CreateOpenConnectionAsync();
        await SampleTypeBulkInserter.ExecuteAsync(connection, items, cancellationToken: TestContext.Current.CancellationToken);

        using SqlCommand command = connection.CreateCommand();
        command.CommandText = "SELECT COUNT(*) FROM Employees";
        int count = Convert.ToInt32(await command.ExecuteScalarAsync(TestContext.Current.CancellationToken));
        Assert.Equal(0, count);
    }

    [Fact]
    public async Task ExecuteAsync_WithBatchSize_InsertsAllRows()
    {
        List<SampleType> items =
        [
            new() { FirstName = "Alice", LastName = "Johnson", Age = 35 },
            new() { FirstName = "Bob", LastName = "Williams", Age = 28 },
            new() { FirstName = "Charlie", LastName = "Brown", Age = 42 }
        ];

        using SqlConnection connection = await CreateOpenConnectionAsync();
        await SampleTypeBulkInserter.ExecuteAsync(connection, items, batchSize: 2, cancellationToken: TestContext.Current.CancellationToken);

        using SqlCommand command = connection.CreateCommand();
        command.CommandText = "SELECT COUNT(*) FROM Employees";
        int count = Convert.ToInt32(await command.ExecuteScalarAsync(TestContext.Current.CancellationToken));
        Assert.Equal(3, count);
    }

    [Fact]
    public async Task ExecuteAsync_OpensClosedConnection()
    {
        List<SampleType> items =
        [
            new() { FirstName = "John", LastName = "Doe", Age = 30 }
        ];

        using SqlConnection connection = await CreateOpenConnectionAsync();
        await connection.CloseAsync();
        await SampleTypeBulkInserter.ExecuteAsync(connection, items, cancellationToken: TestContext.Current.CancellationToken);

        Assert.Equal(ConnectionState.Open, connection.State);
        using SqlCommand command = connection.CreateCommand();
        command.CommandText = "SELECT COUNT(*) FROM Employees";
        int count = Convert.ToInt32(await command.ExecuteScalarAsync(TestContext.Current.CancellationToken));
        Assert.Equal(1, count);
    }

    [Fact]
    public async Task ExecuteAsync_ThrowsWhenCanceled()
    {
        List<SampleType> items =
        [
            new() { FirstName = "John", LastName = "Doe", Age = 30 }
        ];

        using SqlConnection connection = await CreateOpenConnectionAsync();
        using CancellationTokenSource cancellationTokenSource = new();
        await cancellationTokenSource.CancelAsync();

        await Assert.ThrowsAnyAsync<OperationCanceledException>(
            () => SampleTypeBulkInserter.ExecuteAsync(connection, items, cancellationToken: cancellationTokenSource.Token));
    }

    [Fact]
    public async Task ExecuteAsync_ThrowsWhenColumnLengthIsExceeded()
    {
        List<SampleType> items =
        [
            new() { FirstName = new string('A', 101), LastName = "Doe", Age = 30 }
        ];

        using SqlConnection connection = await CreateOpenConnectionAsync();

        InvalidOperationException exception = await Assert.ThrowsAsync<InvalidOperationException>(
            () => SampleTypeBulkInserter.ExecuteAsync(connection, items, cancellationToken: TestContext.Current.CancellationToken));

        Assert.Contains("FirstName", exception.Message);
    }

    [Fact]
    public async Task Execute_VerifiesInsertedValues()
    {
        List<SampleType> items =
        [
            new() { FirstName = "John", LastName = "Doe", Age = 30 }
        ];

        using SqlConnection connection = await CreateOpenConnectionAsync();
        SampleTypeBulkInserter.Execute(connection, items);

        using SqlCommand command = connection.CreateCommand();
        command.CommandText = "SELECT FirstName, LastName, Age FROM Employees";
        using SqlDataReader reader = await command.ExecuteReaderAsync(TestContext.Current.CancellationToken);
        Assert.True(await reader.ReadAsync(TestContext.Current.CancellationToken));
        Assert.Equal("John", reader.GetString(0));
        Assert.Equal("Doe", reader.GetString(1));
        Assert.Equal(30, reader.GetInt32(2));
        Assert.False(await reader.ReadAsync(TestContext.Current.CancellationToken));
    }

    [Fact]
    public async Task Execute_EmptyList_InsertsNoRows()
    {
        List<SampleType> items = [];

        using SqlConnection connection = await CreateOpenConnectionAsync();
        SampleTypeBulkInserter.Execute(connection, items);

        using SqlCommand command = connection.CreateCommand();
        command.CommandText = "SELECT COUNT(*) FROM Employees";
        int count = Convert.ToInt32(await command.ExecuteScalarAsync(TestContext.Current.CancellationToken));
        Assert.Equal(0, count);
    }

    [Fact]
    public async Task Execute_WithBatchSize_InsertsAllRows()
    {
        List<SampleType> items =
        [
            new() { FirstName = "Alice", LastName = "Johnson", Age = 35 },
            new() { FirstName = "Bob", LastName = "Williams", Age = 28 },
            new() { FirstName = "Charlie", LastName = "Brown", Age = 42 }
        ];

        using SqlConnection connection = await CreateOpenConnectionAsync();
        SampleTypeBulkInserter.Execute(connection, items, batchSize: 2);

        using SqlCommand command = connection.CreateCommand();
        command.CommandText = "SELECT COUNT(*) FROM Employees";
        int count = Convert.ToInt32(await command.ExecuteScalarAsync(TestContext.Current.CancellationToken));
        Assert.Equal(3, count);
    }
}
