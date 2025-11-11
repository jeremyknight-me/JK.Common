using System;
using System.Data;
using Microsoft.Data.SqlClient;

namespace JK.Common.Data.Sql.Extensions.Parameters;

public static class DecimalParameterExtensions
{
    extension(SqlParameterCollection parameters)
    {
        public SqlParameterCollection AddDecimal(string name, decimal value, byte precision, byte scale)
        {
            SqlParameter parameter = parameters.Add(name, SqlDbType.Decimal);
            parameter.Value = value;
            _ = SetDecimalPrecisionScale(parameter, precision, scale);
            return parameters;
        }

        public SqlParameterCollection AddDecimal(string name, decimal? value, byte precision, byte scale, bool skipIfNull = false)
        {
            if (skipIfNull && !value.HasValue)
            {
                return parameters;
            }

            SqlParameter parameter = parameters.Add(name, SqlDbType.Decimal);
            parameter.Value = value.HasValue ? value : DBNull.Value;
            _ = SetDecimalPrecisionScale(parameter, precision, scale);
            return parameters;
        }
    }

    private static SqlParameter SetDecimalPrecisionScale(SqlParameter parameter, byte precision, byte scale)
    {
        parameter.Precision = precision;
        parameter.Scale = scale;
        return parameter;
    }
}

