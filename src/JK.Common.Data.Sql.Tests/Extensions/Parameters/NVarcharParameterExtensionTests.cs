using JK.Common.Data.Sql.Extensions.Parameters;

namespace JK.Common.Data.Sql.Tests.Extensions.Parameters;

public class NVarcharParameterExtensionTests
{
    [Theory]
    [InlineData("Foo", "123", 3)]
    [InlineData("Bar", "2345", 4)]
    [InlineData("Hi", "345", -1)]
    public void AddNVarchar_Theories(string name, string value, int size)
    {
        using var command = new SqlCommand();
        command.Parameters.AddNVarchar(name, value, size);
        SqlParameter parameter = ParameterAssertHelper.AssertSingleAndReturn(command, name);
        Assert.Equal(value, parameter.Value);
        Assert.Equal(size, parameter.Size);
        AssertDbTypes(parameter);
    }

    [Fact]
    public void AddNVarchar_NoSkipNull_Test()
    {
        using var command = new SqlCommand();
        command.Parameters.AddNVarchar("foo", null, skipIfNull: false);
        SqlParameter parameter = ParameterAssertHelper.AssertSingleAndReturn(command, "foo");
        ParameterAssertHelper.AssertDbNull(parameter);
        AssertDbTypes(parameter);
    }

    [Fact]
    public void AddNVarchar_SkipNull_Test()
    {
        using var command = new SqlCommand();
        command.Parameters.AddNVarchar("hi", null, skipIfNull: true);
        Assert.Empty(command.Parameters);
    }

    [Theory]
    [InlineData(5000)]
    [InlineData(-100)]
    public void AddNVarchar_InvalidSizeException_Theories(int size)
    {
        using var command = new SqlCommand();
        ArgumentOutOfRangeException exception = Assert.Throws<ArgumentOutOfRangeException>(() =>
        {
            command.Parameters.AddNVarchar("foo", null, size);
        });
        Assert.StartsWith("Data type 'nvarchar' must be positive value between 0 and 4000", exception.Message);
    }

    private static void AssertDbTypes(SqlParameter parameter)
    {
        Assert.Equal(DbType.String, parameter.DbType);
        Assert.Equal(SqlDbType.NVarChar, parameter.SqlDbType);
    }
}
