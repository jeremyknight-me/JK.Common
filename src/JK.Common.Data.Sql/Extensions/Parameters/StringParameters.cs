using System;
using System.Data;
using Microsoft.Data.SqlClient;

namespace JK.Common.Data.Sql.Extensions.Parameters;

public static class StringParameters
{
    public static SqlParameterCollection AddAlways(this SqlParameterCollection parameters, string name, string value, SqlDbType databaseType = SqlDbType.NVarChar, int size = -1)
    {
        object parameterValue = string.IsNullOrWhiteSpace(value) ? DBNull.Value : value;
        AddString(parameters, name, parameterValue, databaseType, size);
        return parameters;
    }

    public static SqlParameterCollection AddIfNonNull(this SqlParameterCollection parameters, string name, string? value, SqlDbType databaseType = SqlDbType.NVarChar, int size = -1)
    {
        if (!string.IsNullOrWhiteSpace(value))
        {
            AddString(parameters, name, value, databaseType, size);
        }

        return parameters;
    }

    private static void AddString(SqlParameterCollection parameters, string name, object value, SqlDbType databaseType, int size)
    {
        EnsureValid(databaseType, size);
        var parameter = parameters.Add(name, databaseType);
        parameter.Value = value;
        parameter.Size = size;
    }

    private static void EnsureValid(SqlDbType databaseType, int size)
    {
        if (databaseType == SqlDbType.Char && !CharIsValidSize(size))
        {
            throw new ArgumentOutOfRangeException(
                nameof(size),
                "Data type 'char' must be positive value between 0 and 8000");
        }
        else if (databaseType == SqlDbType.NChar && !NCharIsValidSize(size))
        {
            throw new ArgumentOutOfRangeException(
                nameof(size),
                "Data type 'nchar' must be positive value between 0 and 4000");
        }
    }

    private static bool CharIsValidSize(int size) => size > 0 && size <= 8000;
    private static bool NCharIsValidSize(int size) => size > 0 && size <= 4000;
}
