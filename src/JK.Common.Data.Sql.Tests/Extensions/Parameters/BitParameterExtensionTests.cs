﻿using System.Data;
using JK.Common.Data.Sql.Extensions.Parameters;
using Microsoft.Data.SqlClient;
using Xunit;

namespace JK.Common.Data.Sql.Tests.Extensions.Parameters;

public class BitParameterExtensionTests
{
    [Theory]
    [InlineData("Foo", true)]
    [InlineData("Bar", false)]
    public void AddBit_Theories(string name, bool value)
    {
        using var command = new SqlCommand();
        command.Parameters.AddBit(name, value);
        var parameter = ParameterAssertHelper.AssertSingleAndReturn(command, name);
        Assert.Equal(value, parameter.Value);
        this.AssertDbTypes(parameter);
    }

    [Fact]
    public void AddBit_NoSkipNull_Test()
    {
        using var command = new SqlCommand();
        command.Parameters.AddBit("foo", (bool?)null, skipIfNull: false);
        var parameter = ParameterAssertHelper.AssertSingleAndReturn(command, "foo");
        ParameterAssertHelper.AssertDbNull(parameter);
        this.AssertDbTypes(parameter);
    }

    [Theory]
    [InlineData("Foo", true)]
    [InlineData("Bar", false)]
    public void AddBit_NonNull_Theories(string name, bool? value)
    {
        using var command = new SqlCommand();
        command.Parameters.AddBit(name, value);
        var parameter = ParameterAssertHelper.AssertSingleAndReturn(command, name);
        Assert.Equal(value, parameter.Value);
        this.AssertDbTypes(parameter);
    }

    [Fact]
    public void AddBit_SkipNull_Test()
    {
        using var command = new SqlCommand();
        command.Parameters.AddBit("hi", (bool?)null, skipIfNull: true);
        Assert.Empty(command.Parameters);
    }

    private void AssertDbTypes(SqlParameter parameter)
    {
        Assert.Equal(DbType.Boolean, parameter.DbType);
        Assert.Equal(SqlDbType.Bit, parameter.SqlDbType);
    }
}
