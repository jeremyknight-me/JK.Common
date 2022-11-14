using System;
using System.Data;
using Microsoft.Data.SqlClient;

namespace JK.Common.Data.Sql.Extensions.Parameters;

public static class DateTimeParameter
{
    public static SqlParameterCollection AddAlways(this SqlParameterCollection parameters, string name, DateTime value, SqlDbType databaseType = SqlDbType.DateTime, byte? precision = null)
    {
        AddDateTime(parameters, name, value, databaseType, precision);
        return parameters;
    }

    public static SqlParameterCollection AddAlways(this SqlParameterCollection parameters, string name, DateTime? value, SqlDbType databaseType = SqlDbType.DateTime, byte? precision = null)
    {
        object parameterValue = value.HasValue ? value : DBNull.Value;
        AddDateTime(parameters, name, parameterValue, databaseType, precision);
        return parameters;
    }

    public static SqlParameterCollection AddIfNonNull(this SqlParameterCollection parameters, string name, DateTime? value, SqlDbType databaseType = SqlDbType.DateTime, byte? precision = null)
    {
        if (value is not null)
        {
            AddDateTime(parameters, name, value, databaseType, precision);
        }

        return parameters;
    }

    private static void AddDateTime(SqlParameterCollection parameters, string name, object value, SqlDbType databaseType, byte? precision)
    {
        var parameter = parameters.Add(name, databaseType);
        parameter.Value = value;
        if (databaseType == SqlDbType.DateTime2 && precision.HasValue)
        {
            parameter.Precision = precision.Value;
        }
    }
}
