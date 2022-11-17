using System.Data;
using Microsoft.Data.SqlClient;

namespace JK.Common.Data.Sql.Extensions.Parameters;

public static class TinyIntParameterExtensions
{
    public static SqlParameterCollection AddTinyInt(this SqlParameterCollection parameters, string name, byte value)
        => parameters.AddByDbType(name, SqlDbType.TinyInt, value);

    public static SqlParameterCollection AddTinyInt(this SqlParameterCollection parameters, string name, byte? value, bool skipIfNull = false)
        => skipIfNull && !value.HasValue
            ? parameters
            : parameters.AddByDbType(name, SqlDbType.TinyInt, value);
}
