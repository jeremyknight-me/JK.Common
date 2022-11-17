using System;
using System.Data;
using JK.Common.Data.Sql.Extensions.Parameters;
using Microsoft.Data.SqlClient;
using Xunit;

namespace JK.Common.Data.Sql.Tests.Extensions.Parameters;

public class VarcharParameterExtensionTests
{
    [Theory]
    [InlineData("Foo", "123", 3)]
    [InlineData("Bar", "2345", 4)]
    [InlineData("Hi", "345", -1)]
    public void AddVarchar_Theories(string name, string value, int size)
    {
        using var command = new SqlCommand();
        command.Parameters.AddVarchar(name, value, size);
        var parameter = ParameterAssertHelper.AssertSingleAndReturn(command, name);
        Assert.Equal(value, parameter.Value);
        Assert.Equal(size, parameter.Size);
        this.AssertDbTypes(parameter);
    }

    [Fact]
    public void AddVarchar_NoSkipNull_Tests()
    {
        using var command = new SqlCommand();
        command.Parameters.AddVarchar("foo", null, skipIfNull: false);
        var parameter = ParameterAssertHelper.AssertSingleAndReturn(command, "foo");
        ParameterAssertHelper.AssertDbNull(parameter);
        this.AssertDbTypes(parameter);
    }

    [Fact]
    public void AddIfNonNull_SkipNull_Test()
    {
        using var command = new SqlCommand();
        command.Parameters.AddVarchar("hi", null, skipIfNull: true);
        Assert.Empty(command.Parameters);
    }

    [Theory]
    [InlineData(9000)]
    [InlineData(-100)]
    public void AddVarchar_InvalidSizeException_Theories(int size)
    {
        using var command = new SqlCommand();
        var exception = Assert.Throws<ArgumentOutOfRangeException>(() =>
        {
            command.Parameters.AddVarchar("foo", null, size);
        });
        Assert.StartsWith("Data type 'varchar' must be positive value between 0 and 8000", exception.Message);
    }

    private void AssertDbTypes(SqlParameter parameter)
    {
        Assert.Equal(DbType.AnsiString, parameter.DbType);
        Assert.Equal(SqlDbType.VarChar, parameter.SqlDbType);
    }
}
