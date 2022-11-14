using System;
using System.Data;
using Microsoft.Data.SqlClient;

namespace JK.Common.Data.Sql.Extensions.Parameters;

public static class DateTimeOffsetParameter
{
    public static SqlParameterCollection AddAlways(this SqlParameterCollection parameters, string name, DateTimeOffset value, byte? precision = null)
    {
        AddDateTimeOffset(parameters, name, value, precision);
        return parameters;
    }

    public static SqlParameterCollection AddAlways(this SqlParameterCollection parameters, string name, DateTimeOffset? value, byte? precision = null)
    {
        object parameterValue = value.HasValue ? value : DBNull.Value;
        AddDateTimeOffset(parameters, name, parameterValue, precision);
        return parameters;
    }

    public static SqlParameterCollection AddIfNonNull(this SqlParameterCollection parameters, string name, DateTimeOffset? value, byte? precision = null)
    {
        if (value is not null)
        {
            AddDateTimeOffset(parameters, name, value, precision);
        }

        return parameters;
    }

    private static void AddDateTimeOffset(SqlParameterCollection parameters, string name, object value, byte? precision)
    {
        var parameter = parameters.Add(name, SqlDbType.DateTimeOffset);
        parameter.Value = value;
        if (precision.HasValue)
        {
            parameter.Precision = precision.Value;
        }
    }
}
