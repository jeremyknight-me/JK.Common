using System;
using System.Data;
using Microsoft.Data.SqlClient;

namespace JK.Common.Data.Sql.Extensions.Parameters;

public static class IntParameters
{
    public static SqlParameterCollection AddAlways(this SqlParameterCollection parameters, string name, int value)
    {
        parameters.Add(name, SqlDbType.Int).Value = value;
        return parameters;
    }

    public static SqlParameterCollection AddAlways(this SqlParameterCollection parameters, string name, int? value)
    {
        parameters.Add(name, SqlDbType.Int).Value = value.HasValue ? value : DBNull.Value;
        return parameters;
    }

    public static SqlParameterCollection AddIfNonNull(this SqlParameterCollection parameters, string name, int? value)
        => parameters.AddIfNonNull(name, SqlDbType.Int, value);
}

