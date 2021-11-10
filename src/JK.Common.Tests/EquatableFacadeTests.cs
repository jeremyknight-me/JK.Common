namespace JK.Common.Tests;

public class EquatableFacadeTests
{
    [Fact]
    public void AreEqual_BothNull_ReturnsTrue()
    {
        var sut = new EquatableFacade<SimpleObject>();
        SimpleObject left = null;
        SimpleObject right = null;
        var actual = sut.AreEqual(left, right);
        Assert.True(actual);
    }

    [Fact]
    public void AreEqual_LeftNullRightNotNull_ReturnsFalse()
    {
        var sut = new EquatableFacade<SimpleObject>();
        SimpleObject left = null;
        SimpleObject right = new();
        var actual = sut.AreEqual(left, right);
        Assert.False(actual);
    }

    [Fact]
    public void AreEqual_LeftNotNullRightNull_ReturnsFalse()
    {
        var sut = new EquatableFacade<SimpleObject>();
        SimpleObject left = new();
        SimpleObject right = null;
        var actual = sut.AreEqual(left, right);
        Assert.False(actual);
    }

    [Fact]
    public void AreEqual_SameReference_ReturnsTrue()
    {
        var sut = new EquatableFacade<SimpleObject>();
        var left = new SimpleObject();
        SimpleObject right = left;
        var actual = sut.AreEqual(left, right);
        Assert.True(actual);
    }

    [Theory]
    [InlineData(1, "Title 1", 1, "Title 1", true)]
    [InlineData(1, "Title 1", 2, "Title 2", false)]
    public void AreEqual_Theories(int id1, string title1, int id2, string title2, bool expected)
    {
        var left = new SimpleObject { Id = id1, Title = title1 };
        var right = new SimpleObject { Id = id2, Title = title2 };
        var sut = new EquatableFacade<SimpleObject>
        {
            AreObjectsEqual = (left, right) => left.Id == right.Id && left.Title == right.Title
        };
        var actual = sut.AreEqual(left, right);
        Assert.Equal(expected, actual);
    }
}
