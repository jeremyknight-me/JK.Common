using Microsoft.Data.SqlClient;

namespace JK.Common.Data.Sql.Extensions;

public static class SqlExceptionExtensions
{
    public static bool IsTimeoutError(this SqlException exception)
        => exception.Number == -2;
}
