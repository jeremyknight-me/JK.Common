namespace JK.Common.Data.Sql.Extensions.Parameters;

/// <summary>
/// Extension methods for adding <see cref="SqlDbType.TinyInt"/> parameters to a <see cref="SqlParameterCollection"/>.
/// </summary>
public static class TinyIntParameterExtensions
{
    extension(SqlParameterCollection parameters)
    {
        public SqlParameterCollection AddTinyInt(string name, byte value)
            => parameters.AddByDbType(name, SqlDbType.TinyInt, value);

        public SqlParameterCollection AddTinyInt(string name, byte? value, bool skipIfNull = false)
            => skipIfNull && !value.HasValue
                ? parameters
                : parameters.AddByDbType(name, SqlDbType.TinyInt, value);
    }
}
