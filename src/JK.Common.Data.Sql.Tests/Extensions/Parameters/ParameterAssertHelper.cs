using System;
using Microsoft.Data.SqlClient;
using Xunit;

namespace JK.Common.Data.Sql.Tests.Extensions.Parameters;

internal static class ParameterAssertHelper
{
    internal static void AssertDbNull(SqlParameter parameter)
        => Assert.Equal(DBNull.Value, parameter.Value);

    internal static SqlParameter AssertSingleAndReturn(SqlCommand command, string expectedName)
    {
        Assert.Single(command.Parameters);
        SqlParameter parameter = command.Parameters[0];
        Assert.Equal(expectedName, parameter.ParameterName);
        return parameter;
    }
}
