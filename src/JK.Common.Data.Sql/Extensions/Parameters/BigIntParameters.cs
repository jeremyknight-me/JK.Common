using System.Data;
using Microsoft.Data.SqlClient;

namespace JK.Common.Data.Sql.Extensions.Parameters;

public static class BigIntParameters
{
    public static SqlParameterCollection AddAlways(this SqlParameterCollection parameters, string name, long value)
        => parameters.AddAlways(name, SqlDbType.BigInt, value);

    public static SqlParameterCollection AddAlways(this SqlParameterCollection parameters, string name, long? value)
        => parameters.AddAlways(name, SqlDbType.BigInt, value);

    public static SqlParameterCollection AddIfNonNull(this SqlParameterCollection parameters, string name, long? value)
        => parameters.AddIfNonNull(name, SqlDbType.BigInt, value);
}
