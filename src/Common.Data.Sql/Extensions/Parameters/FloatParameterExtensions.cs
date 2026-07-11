using System.Data;
using Microsoft.Data.SqlClient;

namespace JK.Common.Data.Sql.Extensions.Parameters;

public static class FloatParameterExtensions
{
    extension(SqlParameterCollection parameters)
    {
        public SqlParameterCollection AddFloat(string name, double value)
            => parameters.AddByDbType(name, SqlDbType.Float, value);

        public SqlParameterCollection AddFloat(string name, double? value, bool skipIfNull = false)
            => skipIfNull && !value.HasValue
                ? parameters
                : parameters.AddByDbType(name, SqlDbType.Float, value);

        public SqlParameterCollection AddFloat(string name, float value)
            => parameters.AddByDbType(name, SqlDbType.Float, value);

        public SqlParameterCollection AddFloat(string name, float? value, bool skipIfNull = false)
            => skipIfNull && !value.HasValue
                ? parameters
                : parameters.AddByDbType(name, SqlDbType.Float, value);
    }
}
