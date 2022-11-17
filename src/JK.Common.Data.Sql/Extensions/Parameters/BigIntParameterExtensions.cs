using System.Data;
using Microsoft.Data.SqlClient;

namespace JK.Common.Data.Sql.Extensions.Parameters;

public static class BigIntParameterExtensions
{
    public static SqlParameterCollection AddBigInt(this SqlParameterCollection parameters, string name, long value)
        => parameters.AddByDbType(name, SqlDbType.BigInt, value);

    public static SqlParameterCollection AddBigInt(this SqlParameterCollection parameters, string name, long? value, bool skipIfNull = false)
        => skipIfNull && !value.HasValue
            ? parameters
            : parameters.AddByDbType(name, SqlDbType.BigInt, value);
}
