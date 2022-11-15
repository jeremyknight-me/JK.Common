using System.Data;
using Microsoft.Data.SqlClient;

namespace JK.Common.Data.Sql.Extensions.Parameters;

public static class BitParameters
{
    public static SqlParameterCollection AddAlways(this SqlParameterCollection parameters, string name, bool value)
        => parameters.AddAlways(name, SqlDbType.Bit, value);

    public static SqlParameterCollection AddAlways(this SqlParameterCollection parameters, string name, bool? value)
        => parameters.AddAlways(name, SqlDbType.Bit, value);

    public static SqlParameterCollection AddIfNonNull(this SqlParameterCollection parameters, string name, bool? value)
        => parameters.AddIfNonNull(name, SqlDbType.Bit, value);
}
