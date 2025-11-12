using System;
using System.Data;
using Microsoft.Data.SqlClient;

namespace JK.Common.Data.Sql.Extensions.Parameters;

internal static class ParameterExtensions
{
    extension(SqlParameterCollection parameters)
    {
        internal SqlParameterCollection AddByDbType(string name, SqlDbType databaseType, object value)
        {
            parameters.Add(name, databaseType).Value = value is null ? DBNull.Value : value;
            return parameters;
        }
    }
}
