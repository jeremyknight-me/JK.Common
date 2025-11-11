namespace JK.Common.Data.Sql.Extensions;

public static class SqlExceptionExtensions
{
    extension(SqlException exception)
    {
        public bool IsTimeoutError() => exception.Number == -2;
    }
}
