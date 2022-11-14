using System.Data;
using Microsoft.Data.SqlClient;

namespace JK.Common.Data.Sql.Extensions.Parameters;

internal static class ParameterHelper
{
    internal static SqlParameterCollection AddIfNonNull(this SqlParameterCollection parameters, string name, SqlDbType databaseType, object? value)
    {
        if (value is not null)
        {
            parameters.Add(name, databaseType).Value = value;
        }

        return parameters;
    }
}
