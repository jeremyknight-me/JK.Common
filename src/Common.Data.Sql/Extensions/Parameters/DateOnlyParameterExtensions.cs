#if NET6_0_OR_GREATER

using System;
using System.Data;
using Microsoft.Data.SqlClient;

namespace JK.Common.Data.Sql.Extensions.Parameters;

/// <summary>
/// Extension methods for adding <see cref="SqlDbType.Date"/> parameters to a <see cref="SqlParameterCollection"/>.
/// </summary>
public static class DateOnlyParameterExtensions
{
    extension(SqlParameterCollection parameters)
    {
        public SqlParameterCollection AddDate(string name, DateOnly value)
            => parameters.AddByDbType(name, SqlDbType.Date, value);

        public SqlParameterCollection AddDate(string name, DateOnly? value, bool skipIfNull = false)
            => skipIfNull && !value.HasValue
                ? parameters
                : parameters.AddByDbType(name, SqlDbType.Date, value);
    }
}

#endif
