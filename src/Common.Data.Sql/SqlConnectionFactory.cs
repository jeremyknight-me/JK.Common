namespace JK.Common.Data.Sql;

/// <summary>
/// Factory for creating SQL Server connections.
/// </summary>
public sealed class SqlConnectionFactory : IAdoConnectionFactory
{
    private readonly string _connectionString;

    /// <summary>
    /// Initializes a new instance of the <see cref="SqlConnectionFactory"/> class.
    /// </summary>
    /// <param name="sqlConnectionString">The SQL Server connection string.</param>
    public SqlConnectionFactory(string sqlConnectionString)
    {
        _connectionString = sqlConnectionString;
    }

    /// <summary>
    /// Creates a new SQL connection.
    /// </summary>
    /// <returns>A new <see cref="IDbConnection"/> instance.</returns>
    public IDbConnection Make() => new SqlConnection(_connectionString);
}
