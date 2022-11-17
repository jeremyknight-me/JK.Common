using System;
using System.Data;
using Microsoft.Data.SqlClient;

namespace JK.Common.Data.Sql.Extensions.Parameters;

public static class UniqueIdentifierParameterExtensions
{
    public static SqlParameterCollection AddUniqueIdentifier(this SqlParameterCollection parameters, string name, Guid value)
        => parameters.AddByDbType(name, SqlDbType.UniqueIdentifier, value);

    public static SqlParameterCollection AddUniqueIdentifier(this SqlParameterCollection parameters, string name, Guid? value, bool skipIfNull = false)
        => skipIfNull && !value.HasValue
            ? parameters
            : parameters.AddByDbType(name, SqlDbType.UniqueIdentifier, value);
}
