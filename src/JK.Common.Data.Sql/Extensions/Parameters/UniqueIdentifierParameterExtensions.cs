namespace JK.Common.Data.Sql.Extensions.Parameters;

public static class UniqueIdentifierParameterExtensions
{
    extension(SqlParameterCollection parameters)
    {
        public SqlParameterCollection AddUniqueIdentifier(string name, Guid value)
            => parameters.AddByDbType(name, SqlDbType.UniqueIdentifier, value);

        public SqlParameterCollection AddUniqueIdentifier(string name, Guid? value, bool skipIfNull = false)
            => skipIfNull && !value.HasValue
                ? parameters
                : parameters.AddByDbType(name, SqlDbType.UniqueIdentifier, value);
    }
}
