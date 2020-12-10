using System.Data;
using System.Data.SqlClient;
using JK.Common.Data.Ado;

namespace JK.Common.Data.Sql
{
    public class SqlDataContext : DataContextBase
    {
        public SqlDataContext(string connectionString) : base(connectionString)
        {
        }

        protected override IDbConnection MakeConnection() => new SqlConnection(this.ConnectionString);
        public override IParameterFactory MakeParameterFactory(IDbCommand command) => new SqlParameterFactory(command);
    }
}
