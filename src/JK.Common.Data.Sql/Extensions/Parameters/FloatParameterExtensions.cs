using System.Data;
using Microsoft.Data.SqlClient;

namespace JK.Common.Data.Sql.Extensions.Parameters;

public static class FloatParameterExtensions
{
    public static SqlParameterCollection AddAlways(this SqlParameterCollection parameters, string name, double value)
        => parameters.AddAlways(name, SqlDbType.Float, value);

    public static SqlParameterCollection AddAlways(this SqlParameterCollection parameters, string name, double? value)
        => parameters.AddAlways(name, SqlDbType.Float, value);

    public static SqlParameterCollection AddIfNonNull(this SqlParameterCollection parameters, string name, double? value)
        => parameters.AddIfNonNull(name, SqlDbType.Float, value);

    public static SqlParameterCollection AddAlways(this SqlParameterCollection parameters, string name, float value)
        => parameters.AddAlways(name, SqlDbType.Float, value);

    public static SqlParameterCollection AddAlways(this SqlParameterCollection parameters, string name, float? value)
        => parameters.AddAlways(name, SqlDbType.Float, value);

    public static SqlParameterCollection AddIfNonNull(this SqlParameterCollection parameters, string name, float? value)
        => parameters.AddIfNonNull(name, SqlDbType.Float, value);
}

