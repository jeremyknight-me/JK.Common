using System.Data;
using Microsoft.Data.SqlClient;

namespace JK.Common.Data.Sql.Extensions.Parameters;

public static class IntParameterExtensions
{
    public static SqlParameterCollection AddInt(this SqlParameterCollection parameters, string name, int value)
        => parameters.AddByDbType(name, SqlDbType.Int, value);

    public static SqlParameterCollection AddInt(this SqlParameterCollection parameters, string name, int? value, bool skipIfNull = false)
        => skipIfNull && !value.HasValue
            ? parameters
            : parameters.AddByDbType(name, SqlDbType.Int, value);
}
