using JK.Common.Data.Sql.Extensions.Parameters;

namespace JK.Common.Data.Sql.Tests.Extensions.Parameters;

public class TinyIntParameterExtensionTests
{
    [Theory]
    [MemberData(nameof(AddTinyInt_Data))]
    public void AddTinyInt_Theories(string name, byte value)
    {
        using var command = new SqlCommand();
        command.Parameters.AddTinyInt(name, value);
        SqlParameter parameter = ParameterAssertHelper.AssertSingleAndReturn(command, name);
        Assert.Equal(value, parameter.Value);
        AssertDbTypes(parameter);
    }

    [Fact]
    public void AddTinyInt_NoSkipNull_Test()
    {
        using var command = new SqlCommand();
        command.Parameters.AddTinyInt("foo", null, skipIfNull: false);
        SqlParameter parameter = ParameterAssertHelper.AssertSingleAndReturn(command, "foo");
        ParameterAssertHelper.AssertDbNull(parameter);
        AssertDbTypes(parameter);
    }

    [Theory]
    [MemberData(nameof(AddTinyInt_Data))]
    public void AddTinyInt_NonNull_Theories(string name, byte value)
    {
        byte? nullableByte = value;
        using var command = new SqlCommand();
        command.Parameters.AddTinyInt(name, nullableByte);
        SqlParameter parameter = ParameterAssertHelper.AssertSingleAndReturn(command, name);
        Assert.Equal(nullableByte, parameter.Value);
        AssertDbTypes(parameter);
    }

    [Fact]
    public void AddTinyInt_SkipNull_Test()
    {
        using var command = new SqlCommand();
        command.Parameters.AddTinyInt("hi", null, skipIfNull: true);
        Assert.Empty(command.Parameters);
    }

    public static TheoryData<string, byte> AddTinyInt_Data()
        => new()
        {
            { "Foo", 1 },
            { "Bar", 2 }
        };

    private static void AssertDbTypes(SqlParameter parameter)
    {
        Assert.Equal(DbType.Byte, parameter.DbType);
        Assert.Equal(SqlDbType.TinyInt, parameter.SqlDbType);
    }
}
