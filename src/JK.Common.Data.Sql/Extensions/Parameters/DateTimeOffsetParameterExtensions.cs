using System;
using System.Data;
using Microsoft.Data.SqlClient;

namespace JK.Common.Data.Sql.Extensions.Parameters;

public static class DateTimeOffsetParameterExtensions
{
    public static SqlParameterCollection AddDateTimeOffset(this SqlParameterCollection parameters, string name, DateTimeOffset value, byte? precision = null)
    {
        AddParameter(parameters, name, value, precision);
        return parameters;
    }

    public static SqlParameterCollection AddDateTimeOffset(this SqlParameterCollection parameters, string name, DateTimeOffset? value, byte? precision = null, bool skipIfNull = false)
    {
        if (skipIfNull && !value.HasValue)
        {
            return parameters;
        }

        object parameterValue = value.HasValue ? value : DBNull.Value;
        AddParameter(parameters, name, parameterValue, precision);
        return parameters;
    }

    private static void AddParameter(SqlParameterCollection parameters, string name, object value, byte? precision)
    {
        var parameter = parameters.Add(name, SqlDbType.DateTimeOffset);
        parameter.Value = value;
        if (precision.HasValue)
        {
            parameter.Precision = precision.Value;
        }
    }
}
