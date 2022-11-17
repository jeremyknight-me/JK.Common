using System;
using System.Data;
using Microsoft.Data.SqlClient;

namespace JK.Common.Data.Sql.Extensions.Parameters;

public static class StringParameterExtensions
{
    public static SqlParameterCollection AddChar(this SqlParameterCollection parameters, string name, string value, int size, bool skipIfNull = false)
    {
        if (!CharIsValidSize(size))
        {
            throw new ArgumentOutOfRangeException(nameof(size), "Data type 'char' must be positive value between 0 and 8000");
        }

        if (skipIfNull && string.IsNullOrWhiteSpace(value))
        {
            return parameters;
        }

        parameters.AddString(name, value, SqlDbType.Char, size);
        return parameters;
    }

    public static SqlParameterCollection AddNChar(this SqlParameterCollection parameters, string name, string value, int size, bool skipIfNull = false)
    {
        if (!NCharIsValidSize(size))
        {
            throw new ArgumentOutOfRangeException(nameof(size), "Data type 'nchar' must be positive value between 0 and 4000");
        }

        if (skipIfNull && string.IsNullOrWhiteSpace(value))
        {
            return parameters;
        }

        parameters.AddString(name, value, SqlDbType.NChar, size);
        return parameters;
    }

    public static SqlParameterCollection AddVarchar(this SqlParameterCollection parameters, string name, string value, int size = -1, bool skipIfNull = false)
    {
        if (!VarcharIsValidSize(size))
        {
            throw new ArgumentOutOfRangeException(nameof(size), "Data type 'varchar' must be positive value between 0 and 8000 or -1 for 'max'");
        }

        if (skipIfNull && string.IsNullOrWhiteSpace(value))
        {
            return parameters;
        }

        parameters.AddString(name, value, SqlDbType.VarChar, size);
        return parameters;
    }

    public static SqlParameterCollection AddNVarchar(this SqlParameterCollection parameters, string name, string value, int size = -1, bool skipIfNull = false)
    {
        if (!NVarcharIsValidSize(size))
        {
            throw new ArgumentOutOfRangeException(nameof(size), "Data type 'nvarchar' must be positive value between 0 and 4000 or -1 for 'max'");
        }

        if (skipIfNull && string.IsNullOrWhiteSpace(value))
        {
            return parameters;
        }

        parameters.AddString(name, value, SqlDbType.NVarChar, size);
        return parameters;
    }

    private static void AddString(this SqlParameterCollection parameters, string name, string value, SqlDbType databaseType, int size)
    {
        object parameterValue = string.IsNullOrWhiteSpace(value) ? DBNull.Value : value;
        parameters.Add(name, databaseType, size).Value = parameterValue;
    }

    private static bool CharIsValidSize(int size) => IsValidSizeUtf8(size);
    private static bool NCharIsValidSize(int size) => IsValidSizeUtf16(size);
    private static bool VarcharIsValidSize(int size) => size == -1 || IsValidSizeUtf8(size);
    private static bool NVarcharIsValidSize(int size) => size == -1 || IsValidSizeUtf16(size);

    private static bool IsValidSizeUtf8(int size) => size > 0 && size <= 8000;
    private static bool IsValidSizeUtf16(int size) => size > 0 && size <= 4000;
}
