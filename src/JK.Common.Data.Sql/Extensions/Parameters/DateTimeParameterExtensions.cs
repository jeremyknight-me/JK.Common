using System;
using System.Data;
using Microsoft.Data.SqlClient;

namespace JK.Common.Data.Sql.Extensions.Parameters;

public static class DateTimeParameterExtensions
{
    public static SqlParameterCollection AddDate(this SqlParameterCollection parameters, string name, DateTime value)
        => parameters.AddByDbType(name, SqlDbType.Date, value);

    public static SqlParameterCollection AddDate(this SqlParameterCollection parameters, string name, DateTime? value, bool skipIfNull = false)
        => skipIfNull && !value.HasValue
            ? parameters
            : parameters.AddByDbType(name, SqlDbType.Date, value);

    public static SqlParameterCollection AddDateTime(this SqlParameterCollection parameters, string name, DateTime value)
        => parameters.AddByDbType(name, SqlDbType.DateTime, value);

    public static SqlParameterCollection AddDateTime(this SqlParameterCollection parameters, string name, DateTime? value, bool skipIfNull = false)
        => skipIfNull && !value.HasValue
            ? parameters
            : parameters.AddByDbType(name, SqlDbType.DateTime, value);

    public static SqlParameterCollection AddDateTime2(this SqlParameterCollection parameters, string name, DateTime value, byte? precision = null)
    {
        SetDateTime2Values(parameters, name, value, precision);
        return parameters;
    }

    public static SqlParameterCollection AddDateTime2(this SqlParameterCollection parameters, string name, DateTime? value, byte? precision = null, bool skipIfNull = false)
    {
        if (skipIfNull && !value.HasValue)
        {
            return parameters;
        }

        object parameterValue = value is null ? DBNull.Value : value.Value;
        SetDateTime2Values(parameters, name, parameterValue, precision);
        return parameters;
    }

    private static void SetDateTime2Values(SqlParameterCollection parameters, string name, object value, byte? precision)
    {
        var parameter = parameters.Add(name, SqlDbType.DateTime2);
        parameter.Value = value;
        if (precision.HasValue)
        {
            parameter.Precision = precision.Value;
        }
    }
}
