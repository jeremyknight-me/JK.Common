using System.Data;
using Microsoft.Data.SqlClient;

namespace JK.Common.Data.Sql.Extensions.Parameters;

public static class BitParameterExtensions
{
    public static SqlParameterCollection AddBit(this SqlParameterCollection parameters, string name, bool value)
        => parameters.AddByDbType(name, SqlDbType.Bit, value);

    public static SqlParameterCollection AddBit(this SqlParameterCollection parameters, string name, bool? value, bool skipIfNull = false)
        => skipIfNull && !value.HasValue
            ? parameters
            : parameters.AddByDbType(name, SqlDbType.Bit, value);
}
