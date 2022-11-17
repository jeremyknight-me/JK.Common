using System;
using System.Collections.Generic;
using System.Data;
using JK.Common.Data.Sql.Extensions.Parameters;
using Microsoft.Data.SqlClient;
using Xunit;

namespace JK.Common.Data.Sql.Tests.Extensions.Parameters;

public class DateTimeParameterExtensionTests
{
    [Theory]
    [MemberData(nameof(AddDateTime_Data))]
    public void AddDateTime_Theories(string name, DateTime value)
    {
        using var command = new SqlCommand();
        command.Parameters.AddDateTime(name, value);
        var parameter = ParameterAssertHelper.AssertSingleAndReturn(command, name);
        Assert.Equal(value, parameter.Value);
        this.AssertDbTypes(parameter);
    }

    [Fact]
    public void AddDateTime_NoSkipNull_Test()
    {
        using var command = new SqlCommand();
        command.Parameters.AddDateTime("foo", null, skipIfNull: false);
        var parameter = ParameterAssertHelper.AssertSingleAndReturn(command, "foo");
        ParameterAssertHelper.AssertDbNull(parameter);
        this.AssertDbTypes(parameter);
    }

    [Theory]
    [MemberData(nameof(AddDateTime_Data))]
    public void AddDateTime_NonNull_Theories(string name, DateTime? value)
    {
        using var command = new SqlCommand();
        command.Parameters.AddDateTime(name, value);
        var parameter = ParameterAssertHelper.AssertSingleAndReturn(command, name);
        Assert.Equal(value, parameter.Value);
        this.AssertDbTypes(parameter);
    }

    [Fact]
    public void AddDateTime_SkipNull_Test()
    {
        using var command = new SqlCommand();
        command.Parameters.AddDateTime("hi", null, skipIfNull: true);
        Assert.Empty(command.Parameters);
    }

    public static IEnumerable<object[]> AddDateTime_Data()
    {
        yield return new object[] { "Foo", new DateTime(2022, 12, 31) };
        yield return new object[] { "Bar", new DateTime(2022, 11, 1) };
    }

    private void AssertDbTypes(SqlParameter parameter)
    {
        Assert.Equal(DbType.DateTime, parameter.DbType);
        Assert.Equal(SqlDbType.DateTime, parameter.SqlDbType);
    }
}
