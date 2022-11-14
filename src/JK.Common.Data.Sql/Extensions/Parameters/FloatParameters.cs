using System;
using System.Data;
using Microsoft.Data.SqlClient;

namespace JK.Common.Data.Sql.Extensions.Parameters;

public static class FloatParameters
{
    public static SqlParameterCollection AddAlways(this SqlParameterCollection parameters, string name, double value)
    {
        parameters.Add(name, SqlDbType.Float).Value = value;
        return parameters;
    }

    public static SqlParameterCollection AddAlways(this SqlParameterCollection parameters, string name, double? value)
    {
        parameters.Add(name, SqlDbType.Float).Value = value.HasValue ? value : DBNull.Value;
        return parameters;
    }

    public static SqlParameterCollection AddIfNonNull(this SqlParameterCollection parameters, string name, double? value)
        => parameters.AddIfNonNull(name, SqlDbType.Float, value);

    public static SqlParameterCollection AddAlways(this SqlParameterCollection parameters, string name, float value)
    {
        parameters.Add(name, SqlDbType.Float).Value = value;
        return parameters;
    }

    public static SqlParameterCollection AddAlways(this SqlParameterCollection parameters, string name, float? value)
    {
        parameters.Add(name, SqlDbType.Float).Value = value.HasValue ? value : DBNull.Value;
        return parameters;
    }

    public static SqlParameterCollection AddIfNonNull(this SqlParameterCollection parameters, string name, float? value)
        => parameters.AddIfNonNull(name, SqlDbType.Float, value);
}

