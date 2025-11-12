using System;
using System.Data;
using Microsoft.Data.SqlClient;

namespace JK.Common.Data.Sql.Extensions.Parameters;

public static class DateTimeParameterExtensions
{
    extension(SqlParameterCollection parameters)
    {
        public SqlParameterCollection AddDateTime(string name, DateTime value)
            => parameters.AddByDbType(name, SqlDbType.DateTime, value);

        public SqlParameterCollection AddDateTime(string name, DateTime? value, bool skipIfNull = false)
            => skipIfNull && !value.HasValue
                ? parameters
                : parameters.AddByDbType(name, SqlDbType.DateTime, value);

        public SqlParameterCollection AddDateTime2(string name, DateTime value, byte? precision = null)
        {
            SetDateTime2Values(parameters, name, value, precision);
            return parameters;
        }

        public SqlParameterCollection AddDateTime2(string name, DateTime? value, byte? precision = null, bool skipIfNull = false)
        {
            if (skipIfNull && !value.HasValue)
            {
                return parameters;
            }

            object parameterValue = value is null ? DBNull.Value : value.Value;
            SetDateTime2Values(parameters, name, parameterValue, precision);
            return parameters;
        }
    }

    private static void SetDateTime2Values(SqlParameterCollection parameters, string name, object value, byte? precision)
    {
        SqlParameter parameter = parameters.Add(name, SqlDbType.DateTime2);
        parameter.Value = value;
        if (precision.HasValue)
        {
            parameter.Precision = precision.Value;
        }
    }
}
