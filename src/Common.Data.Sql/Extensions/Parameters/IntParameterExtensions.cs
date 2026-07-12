namespace JK.Common.Data.Sql.Extensions.Parameters;

/// <summary>
/// Extension methods for adding <see cref="SqlDbType.Int"/> parameters to a <see cref="SqlParameterCollection"/>.
/// </summary>
public static class IntParameterExtensions
{
    extension(SqlParameterCollection parameters)
    {
        public SqlParameterCollection AddInt(string name, int value)
            => parameters.AddByDbType(name, SqlDbType.Int, value);

        public SqlParameterCollection AddInt(string name, int? value, bool skipIfNull = false)
            => skipIfNull && !value.HasValue
                ? parameters
                : parameters.AddByDbType(name, SqlDbType.Int, value);
    }
}
