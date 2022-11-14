using System;
using System.Data;
using Microsoft.Data.SqlClient;

namespace JK.Common.Data.Sql.Extensions.Parameters;

public static class DecimalParameters
{
    public static SqlParameterCollection AddAlways(this SqlParameterCollection parameters, string name, decimal value, byte precision, byte scale)
    {
        var parameter = parameters.Add(name, SqlDbType.Decimal);
        parameter.Value = value;
        _ = SetDecimalPrecisionScale(parameter, precision, scale);
        return parameters;
    }

    public static SqlParameterCollection AddAlways(this SqlParameterCollection parameters, string name, decimal? value, byte precision, byte scale)
    {
        var parameter = parameters.Add(name, SqlDbType.Decimal);
        parameter.Value = value.HasValue ? value : DBNull.Value;
        _ = SetDecimalPrecisionScale(parameter, precision, scale);
        return parameters;
    }

    public static SqlParameterCollection AddIfNonNull(this SqlParameterCollection parameters, string name, decimal? value, byte precision, byte scale)
    {
        if (value.HasValue)
        {
            var parameter = parameters.Add(name, SqlDbType.Decimal);
            parameter.Value = value;
            _ = SetDecimalPrecisionScale(parameter, precision, scale);
        }

        return parameters;
    }

    private static SqlParameter SetDecimalPrecisionScale(SqlParameter parameter, byte precision, byte scale)
    {
        parameter.Precision = precision;
        parameter.Scale = scale;
        return parameter;
    }
}

