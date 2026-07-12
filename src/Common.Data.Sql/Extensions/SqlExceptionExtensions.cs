namespace JK.Common.Data.Sql.Extensions;

/// <summary>
/// Extension methods for <see cref="SqlException"/>.
/// </summary>
public static class SqlExceptionExtensions
{
    extension(SqlException exception)
    {
        /// <summary>
        /// Determines whether the exception represents a SQL timeout error.
        /// </summary>
        /// <returns><c>true</c> if the exception is a timeout error; otherwise, <c>false</c>.</returns>
        public bool IsTimeoutError() => exception.Number == -2;
    }
}
