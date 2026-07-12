namespace JK.Common.Data.Sql.Extensions.Parameters;

/// <summary>
/// Extension methods for adding <see cref="SqlDbType.SmallInt"/> parameters to a <see cref="SqlParameterCollection"/>.
/// </summary>
public static class SmallIntParameterExtensions
{
    extension(SqlParameterCollection parameters)
    {
        public SqlParameterCollection AddSmallInt(string name, short value)
            => parameters.AddByDbType(name, SqlDbType.SmallInt, value);

        public SqlParameterCollection AddSmallInt(string name, short? value, bool skipIfNull = false)
            => skipIfNull && !value.HasValue
                ? parameters
                : parameters.AddByDbType(name, SqlDbType.SmallInt, value);
    }
}
