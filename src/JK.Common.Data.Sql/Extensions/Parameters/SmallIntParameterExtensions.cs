using System.Data;
using Microsoft.Data.SqlClient;

namespace JK.Common.Data.Sql.Extensions.Parameters;

public static class SmallIntParameterExtensions
{
    public static SqlParameterCollection AddSmallInt(this SqlParameterCollection parameters, string name, short value)
    => parameters.AddByDbType(name, SqlDbType.SmallInt, value);

    public static SqlParameterCollection AddSmallInt(this SqlParameterCollection parameters, string name, short? value, bool skipIfNull = false)
        => skipIfNull && !value.HasValue
            ? parameters
            : parameters.AddByDbType(name, SqlDbType.SmallInt, value);
}
