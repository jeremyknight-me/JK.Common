using System.Data;
using JK.Common.Data.Ado;
using Microsoft.Data.SqlClient;

namespace JK.Common.Data.Sql;

public abstract class SqlDatabase : DatabaseBase
{
    public SqlDatabase(string connectionString) : base(connectionString)
    {
    }

    protected override IDbConnection MakeConnection() => new SqlConnection(this.ConnectionString);
}
