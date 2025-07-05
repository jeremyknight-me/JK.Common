using System.Data;
using Microsoft.Data.SqlClient;

namespace JK.Common.Data.Sql;

public sealed class SqlConnectionFactory : IAdoConnectionFactory
{
    private readonly string _connectionString;

    public SqlConnectionFactory(string sqlConnectionString)
    {
        _connectionString = sqlConnectionString;
    }

    public IDbConnection Make() => new SqlConnection(_connectionString);
}
