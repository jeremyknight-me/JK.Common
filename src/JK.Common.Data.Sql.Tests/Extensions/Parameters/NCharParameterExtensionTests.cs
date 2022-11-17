using System;
using System.Data;
using JK.Common.Data.Sql.Extensions.Parameters;
using Microsoft.Data.SqlClient;
using Xunit;

namespace JK.Common.Data.Sql.Tests.Extensions.Parameters;

public class NCharParameterExtensionTests
{
    [Theory]
    [InlineData("Foo", "123", 3)]
    [InlineData("Bar", "2345", 4)]
    public void AddNChar_Theories(string name, string value, int size)
    {
        using var command = new SqlCommand();
        command.Parameters.AddNChar(name, value, size);
        var parameter = ParameterAssertHelper.AssertSingleAndReturn(command, name);
        Assert.Equal(value, parameter.Value);
        Assert.Equal(size, parameter.Size);
        this.AssertDbTypes(parameter);
    }

    [Fact]
    public void AddNChar_NoSkipNull_Test()
    {
        using var command = new SqlCommand();
        command.Parameters.AddNChar("foo", null, 2, skipIfNull: false);
        var parameter = ParameterAssertHelper.AssertSingleAndReturn(command, "foo");
        ParameterAssertHelper.AssertDbNull(parameter);
        this.AssertDbTypes(parameter);
    }

    [Fact]
    public void AddNChar_SkipNull_Test()
    {
        using var command = new SqlCommand();
        command.Parameters.AddNChar("hi", null, 2, skipIfNull: true);
        Assert.Empty(command.Parameters);
    }

    [Theory]
    [InlineData(5000)]
    [InlineData(-1)]
    [InlineData(-100)]
    public void AddNChar_InvalidSizeException_Theories(int size)
    {
        using var command = new SqlCommand();
        var exception = Assert.Throws<ArgumentOutOfRangeException>(() =>
        {
            command.Parameters.AddNChar("foo", null, size);
        });
        Assert.StartsWith("Data type 'nchar' must be positive value between 0 and 4000", exception.Message);
    }

    private void AssertDbTypes(SqlParameter parameter)
    {
        Assert.Equal(DbType.StringFixedLength, parameter.DbType);
        Assert.Equal(SqlDbType.NChar, parameter.SqlDbType);
    }
}
