using System.Data;
using JK.Common.Data.Sql.Extensions.Parameters;
using Microsoft.Data.SqlClient;
using Xunit;

namespace JK.Common.Data.Sql.Tests.Extensions.Parameters;

public class NVarcharParameterExtensionTests
{
    [Theory]
    [InlineData("Foo", "123", 3)]
    [InlineData("Bar", "2345", 4)]
    [InlineData("Hi", "345", -1)]
    public void AddAlways_Theories(string name, string value, int size)
    {
        using var command = new SqlCommand();
        command.Parameters.AddAlways(name, value, SqlDbType.NVarChar, size);
        var parameter = ParameterAssertHelper.AssertSingleAndReturn(command, name);
        Assert.Equal(value, parameter.Value);
        Assert.Equal(size, parameter.Size);
        this.AssertDbTypes(parameter);
    }

    [Fact]
    public void AddAlways_Null_Test()
    {
        using var command = new SqlCommand();
        command.Parameters.AddAlways("foo", (string)null, SqlDbType.NVarChar);
        var parameter = ParameterAssertHelper.AssertSingleAndReturn(command, "foo");
        ParameterAssertHelper.AssertDbNull(parameter);
        this.AssertDbTypes(parameter);
    }

    [Theory]
    [InlineData("Foo", "123", 3)]
    [InlineData("Bar", "2345", 4)]
    [InlineData("Hi", "345", -1)]
    public void AddIfNonNull_NonNull_Theories(string name, string value, int size)
    {
        using var command = new SqlCommand();
        command.Parameters.AddIfNonNull(name, value, SqlDbType.NVarChar, size);
        var parameter = ParameterAssertHelper.AssertSingleAndReturn(command, name);
        Assert.Equal(value, parameter.Value);
        Assert.Equal(size, parameter.Size);
        this.AssertDbTypes(parameter);
    }

    [Fact]
    public void AddIfNonNull_Null_Test()
    {
        using var command = new SqlCommand();
        command.Parameters.AddIfNonNull("hi", (string)null, SqlDbType.NVarChar);
        Assert.Empty(command.Parameters);
    }

    private void AssertDbTypes(SqlParameter parameter)
    {
        Assert.Equal(DbType.String, parameter.DbType);
        Assert.Equal(SqlDbType.NVarChar, parameter.SqlDbType);
    }
}
