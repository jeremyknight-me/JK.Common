namespace JK.Common.Data.Sql.Extensions.Parameters;

/// <summary>
/// Extension methods for adding <see cref="SqlDbType.Bit"/> parameters to a <see cref="SqlParameterCollection"/>.
/// </summary>
public static class BitParameterExtensions
{
    extension(SqlParameterCollection parameters)
    {
        public SqlParameterCollection AddBit(string name, bool value)
            => parameters.AddByDbType(name, SqlDbType.Bit, value);

        public SqlParameterCollection AddBit(string name, bool? value, bool skipIfNull = false)
            => skipIfNull && !value.HasValue
                ? parameters
                : parameters.AddByDbType(name, SqlDbType.Bit, value);
    }
}
