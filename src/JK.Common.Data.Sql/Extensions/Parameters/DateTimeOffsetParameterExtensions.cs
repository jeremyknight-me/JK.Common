using System;
using System.Data;
using Microsoft.Data.SqlClient;

namespace JK.Common.Data.Sql.Extensions.Parameters;

public static class DateTimeOffsetParameterExtensions
{
    extension(SqlParameterCollection parameters)
    {
        public SqlParameterCollection AddDateTimeOffset(string name, DateTimeOffset value, byte? precision = null)
        {
            AddParameter(parameters, name, value, precision);
            return parameters;
        }

        public SqlParameterCollection AddDateTimeOffset(string name, DateTimeOffset? value, byte? precision = null, bool skipIfNull = false)
        {
            if (skipIfNull && !value.HasValue)
            {
                return parameters;
            }

            object parameterValue = value.HasValue ? value : DBNull.Value;
            AddParameter(parameters, name, parameterValue, precision);
            return parameters;
        }

        private void AddParameter(string name, object value, byte? precision)
        {
            SqlParameter parameter = parameters.Add(name, SqlDbType.DateTimeOffset);
            parameter.Value = value;
            if (precision.HasValue)
            {
                parameter.Precision = precision.Value;
            }
        }
    }
}
