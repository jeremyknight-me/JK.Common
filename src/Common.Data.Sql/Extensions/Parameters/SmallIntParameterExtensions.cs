namespace JK.Common.Data.Sql.Extensions.Parameters;

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
