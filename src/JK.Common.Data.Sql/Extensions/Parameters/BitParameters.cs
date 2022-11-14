using System;
using System.Data;
using Microsoft.Data.SqlClient;

namespace JK.Common.Data.Sql.Extensions.Parameters;

public static class BitParameters
{
    public static SqlParameterCollection AddAlways(this SqlParameterCollection parameters, string name, bool value)
    {
        parameters.Add(name, SqlDbType.Bit).Value = value;
        return parameters;
    }

    public static SqlParameterCollection AddAlways(this SqlParameterCollection parameters, string name, bool? value)
    {
        parameters.Add(name, SqlDbType.Bit).Value = value.HasValue ? value : DBNull.Value;
        return parameters;
    }

    public static SqlParameterCollection AddIfNonNull(this SqlParameterCollection parameters, string name, bool? value)
        => parameters.AddIfNonNull(name, SqlDbType.Bit, value);
}
