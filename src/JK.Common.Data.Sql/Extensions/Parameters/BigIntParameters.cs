using System;
using System.Data;
using Microsoft.Data.SqlClient;

namespace JK.Common.Data.Sql.Extensions.Parameters;

public static class BigIntParameters
{
    public static SqlParameterCollection AddAlways(this SqlParameterCollection parameters, string name, long value)
    {
        parameters.Add(name, SqlDbType.BigInt).Value = value;
        return parameters;
    }

    public static SqlParameterCollection AddAlways(this SqlParameterCollection parameters, string name, long? value)
    {
        parameters.Add(name, SqlDbType.BigInt).Value = value.HasValue ? value : DBNull.Value;
        return parameters;
    }

    public static SqlParameterCollection AddIfNonNull(this SqlParameterCollection parameters, string name, long? value)
        => parameters.AddIfNonNull(name, SqlDbType.BigInt, value);
}

