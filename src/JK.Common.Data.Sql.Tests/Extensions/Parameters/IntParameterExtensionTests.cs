using System.Data;
using JK.Common.Data.Sql.Extensions.Parameters;
using Microsoft.Data.SqlClient;
using Xunit;

namespace JK.Common.Data.Sql.Tests.Extensions.Parameters;

public class IntParameterExtensionTests
{
    [Theory]
    [InlineData("Foo", 1)]
    [InlineData("Bar", 2)]
    public void AddAlways_Theories(string name, int value)
    {
        using var command = new SqlCommand();
        command.Parameters.AddInt(name, value);
        var parameter = ParameterAssertHelper.AssertSingleAndReturn(command, name);
        Assert.Equal(value, parameter.Value);
        this.AssertDbTypes(parameter);
    }

    [Fact]
    public void AddAlways_Null_Tests()
    {
        using var command = new SqlCommand();
        command.Parameters.AddInt("foo", null, skipIfNull: false);
        var parameter = ParameterAssertHelper.AssertSingleAndReturn(command, "foo");
        ParameterAssertHelper.AssertDbNull(parameter);
        this.AssertDbTypes(parameter);
    }

    [Theory]
    [InlineData("Foo", 1)]
    [InlineData("Bar", 2)]
    public void AddIfNonNull_NonNull_Theories(string name, int? value)
    {
        using var command = new SqlCommand();
        command.Parameters.AddInt(name, value);
        var parameter = ParameterAssertHelper.AssertSingleAndReturn(command, name);
        Assert.Equal(value, parameter.Value);
        this.AssertDbTypes(parameter);
    }

    [Fact]
    public void AddIfNonNull_Null_Test()
    {
        using var command = new SqlCommand();
        command.Parameters.AddInt("hi", null, skipIfNull: true);
        Assert.Empty(command.Parameters);
    }

    private void AssertDbTypes(SqlParameter parameter)
    {
        Assert.Equal(DbType.Int32, parameter.DbType);
        Assert.Equal(SqlDbType.Int, parameter.SqlDbType);
    }
}
