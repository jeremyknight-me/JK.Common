using JK.Common.Extensions;

namespace JK.Common.Tests.Extensions.QueryableExtensionTests;

public class SortByPredicate
{
    [Fact]
    public void NoSource_Exception()
    {
        IQueryable<SimpleObject> list = null;
        ArgumentNullException ex = Assert.Throws<ArgumentNullException>(() => list.SortBy(x => x.Title));
    }

    [Fact]
    public void Ascending_SortedList()
    {
        IQueryable<SimpleObject> list = SimpleObject.GetMockDataSetAsQueryable();
        SimpleObject[] items = list.SortBy(x => x.Title).ToArray();
        Assert.Equal(1, items[0].Id);
        Assert.Equal("Title 1", items[0].Title);
    }

    [Fact]
    public void Descending_SortedList()
    {
        IQueryable<SimpleObject> list = SimpleObject.GetMockDataSetAsQueryable();
        SimpleObject[] items = list.SortBy(x => x.Title, false).ToArray();
        Assert.Equal(5, items[0].Id);
        Assert.Equal("Title 5", items[0].Title);
    }

    [Fact]
    public void AscendingWithSkip_SortedList()
    {
        IQueryable<SimpleObject> list = SimpleObject.GetMockDataSetAsQueryable();
        SimpleObject[] items = list.SortBy(x => x.Title).Skip(2).ToArray();
        Assert.Equal(3, items[0].Id);
        Assert.Equal("Title 3", items[0].Title);
    }

    [Fact]
    public void DescendingWithSkip_SortedList()
    {
        IQueryable<SimpleObject> list = SimpleObject.GetMockDataSetAsQueryable();
        SimpleObject[] items = list.SortBy(x => x.Title, false).Skip(2).ToArray();
        Assert.Equal(3, items[0].Id);
        Assert.Equal("Title 3", items[0].Title);
    }
}
