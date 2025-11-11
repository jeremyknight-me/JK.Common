namespace JK.Common.Data.Sql.Extensions.Parameters;

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
