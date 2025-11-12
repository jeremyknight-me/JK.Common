namespace JK.Common.Data.Sql.Extensions.Parameters;

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
