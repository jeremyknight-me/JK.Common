using JK.Common.Data.Ado;
using Microsoft.Data.SqlClient;

namespace JK.Common.Data.Sql;

public abstract class SqlDatabase : AdoDatabase<SqlConnection>
{
    public SqlDatabase(string connectionString) : base(connectionString)
    {
    }

    protected override SqlConnection MakeConnection(string connectionString)
        => new(connectionString);
}
