using System.Data;
using JK.Common.Data.Ado;
using Microsoft.Data.SqlClient;

namespace JK.Common.Data.Sql;

public class SqlDataContext : DataContextBase
{
    public SqlDataContext(string connectionString) : base(connectionString)
    {
    }

    protected override IDbConnection MakeConnection() => new SqlConnection(this.ConnectionString);
    public override IParameterFactory MakeParameterFactory(IDbCommand command) => new SqlParameterFactory(command);
}
