using System.Data;
using JK.Common.Data.Ado;
using Microsoft.Data.SqlClient;

namespace JK.Common.Data.Sql;

public sealed class SqlConnectionFactory : IAdoConnectionFactory
{
    private readonly string connectionString;

    public SqlConnectionFactory(string sqlConnectionString)
    {
        this.connectionString = sqlConnectionString;
    }

    public IDbConnection Make() => new SqlConnection(this.connectionString);
}
