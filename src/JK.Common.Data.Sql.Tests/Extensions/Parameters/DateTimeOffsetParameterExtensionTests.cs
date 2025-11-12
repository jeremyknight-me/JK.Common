using JK.Common.Data.Sql.Extensions.Parameters;

namespace JK.Common.Data.Sql.Tests.Extensions.Parameters;

public class DateTimeOffsetParameterExtensionTests
{
    [Theory]
    [MemberData(nameof(AddAlways_Data))]
    public void AddDateTimeOffset_Theories(string name, DateTimeOffset value)
    {
        using var command = new SqlCommand();
        command.Parameters.AddDateTimeOffset(name, value);
        SqlParameter parameter = ParameterAssertHelper.AssertSingleAndReturn(command, name);
        Assert.Equal(value, parameter.Value);
        AssertDbTypes(parameter);
    }

    [Fact]
    public void AddDateTimeOffset_NoSkipNull_Test()
    {
        using var command = new SqlCommand();
        command.Parameters.AddDateTimeOffset("foo", null, skipIfNull: false);
        SqlParameter parameter = ParameterAssertHelper.AssertSingleAndReturn(command, "foo");
        ParameterAssertHelper.AssertDbNull(parameter);
        AssertDbTypes(parameter);
    }

    [Theory]
    [MemberData(nameof(AddAlways_Data))]
    public void AddDateTimeOffset_NonNull_Theories(string name, DateTimeOffset value)
    {
        DateTimeOffset? nullableDateTimeOffset = value;
        using var command = new SqlCommand();
        command.Parameters.AddDateTimeOffset(name, nullableDateTimeOffset);
        SqlParameter parameter = ParameterAssertHelper.AssertSingleAndReturn(command, name);
        Assert.Equal(nullableDateTimeOffset, parameter.Value);
        AssertDbTypes(parameter);
    }

    [Fact]
    public void AddDateTimeOffset_SkipNull_Test()
    {
        using var command = new SqlCommand();
        command.Parameters.AddDateTimeOffset("hi", null, skipIfNull: true);
        Assert.Empty(command.Parameters);
    }

    public static TheoryData<string, DateTimeOffset> AddAlways_Data()
        => new()
        {
            { "Foo", new DateTimeOffset(new DateTime(2022, 12, 31)) },
            { "Bar", new DateTimeOffset(new DateTime(2022, 11, 1)) }
        };

    private static void AssertDbTypes(SqlParameter parameter)
    {
        Assert.Equal(DbType.DateTimeOffset, parameter.DbType);
        Assert.Equal(SqlDbType.DateTimeOffset, parameter.SqlDbType);
    }
}
