using System;
using System.Data;
using Microsoft.Data.SqlClient;

namespace JK.Common.Data.Sql.Extensions.Parameters;

public static class UniqueIdentifierParameter
{
    public static SqlParameterCollection AddAlways(this SqlParameterCollection parameters, string name, Guid value)
    {
        parameters.Add(name, SqlDbType.UniqueIdentifier).Value = value;
        return parameters;
    }

    public static SqlParameterCollection AddAlways(this SqlParameterCollection parameters, string name, Guid? value)
    {
        parameters.Add(name, SqlDbType.UniqueIdentifier).Value = value.HasValue ? value : DBNull.Value;
        return parameters;
    }

    public static SqlParameterCollection AddIfNonNull(this SqlParameterCollection parameters, string name, Guid? value)
        => parameters.AddIfNonNull(name, SqlDbType.UniqueIdentifier, value);
}
