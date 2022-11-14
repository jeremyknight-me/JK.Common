﻿using System;
using System.Collections.Generic;
using System.Data;
using JK.Common.Data.Sql.Extensions.Parameters;
using Microsoft.Data.SqlClient;
using Xunit;

namespace JK.Common.Data.Sql.Tests.Extensions.Parameters;

public class DateTimeOffsetParameterTests
{
    [Theory]
    [MemberData(nameof(AddAlways_Data))]
    public void AddAlways_Theories(string name, DateTimeOffset value)
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
        command.Parameters.AddAlways("foo", (DateTimeOffset?)null);
        var parameter = ParameterAssertHelper.AssertSingleAndReturn(command, "foo");
        ParameterAssertHelper.AssertDbNull(parameter);
        this.AssertDbTypes(parameter);
    }

    [Theory]
    [MemberData(nameof(AddAlways_Data))]
    public void AddIfNonNull_NonNull_Theories(string name, DateTimeOffset? value)
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
        command.Parameters.AddIfNonNull("hi", (DateTimeOffset?)null);
        Assert.Empty(command.Parameters);
    }

    public static IEnumerable<object[]> AddAlways_Data()
    {
        yield return new object[] { "Foo", new DateTimeOffset(new DateTime(2022, 12, 31)) };
        yield return new object[] { "Bar", new DateTimeOffset(new DateTime(2022, 11, 1)) };
    }

    private void AssertDbTypes(SqlParameter parameter)
    {
        Assert.Equal(DbType.DateTimeOffset, parameter.DbType);
        Assert.Equal(SqlDbType.DateTimeOffset, parameter.SqlDbType);
    }
}
