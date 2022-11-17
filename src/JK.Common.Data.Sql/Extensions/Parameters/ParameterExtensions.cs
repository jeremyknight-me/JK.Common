using System;
using System.Data;
using Microsoft.Data.SqlClient;

namespace JK.Common.Data.Sql.Extensions.Parameters;

internal static class ParameterExtensions
{
    internal static SqlParameterCollection AddByDbType(this SqlParameterCollection parameters, string name, SqlDbType databaseType, object value)
    {
        parameters.Add(name, databaseType).Value = value is null ? DBNull.Value : value;
        return parameters;
    }
}
