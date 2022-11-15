using System.Data;
using Microsoft.Data.SqlClient;

namespace JK.Common.Data.Sql.Extensions.Parameters;

public static class SmallIntParameters
{
    public static SqlParameterCollection AddAlways(this SqlParameterCollection parameters, string name, short value)
        => parameters.AddAlways(name, SqlDbType.SmallInt, value);

    public static SqlParameterCollection AddAlways(this SqlParameterCollection parameters, string name, short? value)
        => parameters.AddAlways(name, SqlDbType.SmallInt, value);

    public static SqlParameterCollection AddIfNonNull(this SqlParameterCollection parameters, string name, short? value)
        => parameters.AddIfNonNull(name, SqlDbType.SmallInt, value);
}
