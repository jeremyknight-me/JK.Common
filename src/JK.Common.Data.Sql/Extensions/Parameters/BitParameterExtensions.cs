using System.Data;
using Microsoft.Data.SqlClient;

namespace JK.Common.Data.Sql.Extensions.Parameters;

public static class BitParameterExtensions
{
    extension(SqlParameterCollection parameters)
    {
        public SqlParameterCollection AddBit(string name, bool value)
            => parameters.AddByDbType(name, SqlDbType.Bit, value);

        public SqlParameterCollection AddBit(string name, bool? value, bool skipIfNull = false)
            => skipIfNull && !value.HasValue
                ? parameters
                : parameters.AddByDbType(name, SqlDbType.Bit, value);
    }
}
