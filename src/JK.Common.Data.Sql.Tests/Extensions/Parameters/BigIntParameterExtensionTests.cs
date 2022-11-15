using System.Data;
using JK.Common.Data.Sql.Extensions.Parameters;
using Microsoft.Data.SqlClient;
using Xunit;

namespace JK.Common.Data.Sql.Tests.Extensions.Parameters;

public class BigIntParameterExtensionTests
{
    [Theory]
    [InlineData("Foo", 1)]
    [InlineData("Bar", 2)]
    public void AddAlways_Theories(string name, long value)
    {
        using var command = new SqlCommand();
        command.Parameters.AddAlways(name, value);
        var parameter = ParameterAssertHelper.AssertSingleAndReturn(command, name);
        Assert.Equal(value, parameter.Value);
        this.AssertDbTypes(parameter);
    }

    [Fact]
    public void AddAlways_Null_Tests()
    {
        using var command = new SqlCommand();
        command.Parameters.AddAlways("foo", (long?)null);
        var parameter = ParameterAssertHelper.AssertSingleAndReturn(command, "foo");
        ParameterAssertHelper.AssertDbNull(parameter);
        this.AssertDbTypes(parameter);
    }

    [Theory]
    [InlineData("Foo", 1)]
    [InlineData("Bar", 2)]
    public void AddIfNonNull_NonNull_Theories(string name, long? value)
    {
        using var command = new SqlCommand();
        command.Parameters.AddIfNonNull(name, value);
        var parameter = ParameterAssertHelper.AssertSingleAndReturn(command, name);
        Assert.Equal(value, parameter.Value);
        this.AssertDbTypes(parameter);
    }

    [Fact]
    public void AddIfNonNull_Null_Test()
    {
        using var command = new SqlCommand();
        command.Parameters.AddIfNonNull("hi", (long?)null);
        Assert.Empty(command.Parameters);
    }

    private void AssertDbTypes(SqlParameter parameter)
    {
        Assert.Equal(DbType.Int64, parameter.DbType);
        Assert.Equal(SqlDbType.BigInt, parameter.SqlDbType);
    }
}
