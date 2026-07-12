namespace JK.Common.Data.Sql.Extensions.Parameters;

/// <summary>
/// Extension methods for adding <see cref="SqlDbType.BigInt"/> parameters to a <see cref="SqlParameterCollection"/>.
/// </summary>
public static class BigIntParameterExtensions
{
    extension(SqlParameterCollection parameters)
    {
        public SqlParameterCollection AddBigInt(string name, long value)
            => parameters.AddByDbType(name, SqlDbType.BigInt, value);

        public SqlParameterCollection AddBigInt(string name, long? value, bool skipIfNull = false)
            => skipIfNull && !value.HasValue
                ? parameters
                : parameters.AddByDbType(name, SqlDbType.BigInt, value);
    }
}
