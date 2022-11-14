using System;
using System.Data;
using Microsoft.Data.SqlClient;

namespace JK.Common.Data.Sql.Extensions.Parameters;

public static class TinyIntParameters
{
    public static SqlParameterCollection AddAlways(this SqlParameterCollection parameters, string name, byte value)
    {
        parameters.Add(name, SqlDbType.TinyInt).Value = value;
        return parameters;
    }

    public static SqlParameterCollection AddAlways(this SqlParameterCollection parameters, string name, byte? value)
    {
        parameters.Add(name, SqlDbType.TinyInt).Value = value.HasValue ? value : DBNull.Value;
        return parameters;
    }

    public static SqlParameterCollection AddIfNonNull(this SqlParameterCollection parameters, string name, byte? value)
        => parameters.AddIfNonNull(name, SqlDbType.TinyInt, value);
}

