using System.Linq;
using JK.Common.Extensions;

namespace JK.Common.Tests.Extensions.QueryableExtensionTests;

public class SortByString
{
    [Fact]
    public void SortBy_NoSource_Exception()
    {
        IQueryable<SimpleObject> list = null;
        ArgumentNullException ex = Assert.Throws<ArgumentNullException>(() => list.SortBy("Title"));
    }

    [Fact]
    public void SortBy_NoKeySelector_Source()
    {
        Func<SimpleObject, dynamic> key = null;
        IQueryable<SimpleObject> list = SimpleObject.GetMockDataSetAsQueryable();
        IQueryable<SimpleObject> items = list.SortBy(key);
        Assert.Equal(list, items);
    }

    [Fact]
    public void NoPropertyName_UnsortedList()
    {
        IQueryable<SimpleObject> list = SimpleObject.GetMockDataSetAsQueryable();
        SimpleObject[] items = list.SortBy(null).ToArray();
        Assert.Equal(1, items[0].Id);
        Assert.Equal("Title 1", items[0].Title);
    }

    [Fact]
    public void Ascending_SortedList()
    {
        IQueryable<SimpleObject> list = SimpleObject.GetMockDataSetAsQueryable();
        SimpleObject[] items = list.SortBy("Title").ToArray();
        Assert.Equal(1, items[0].Id);
        Assert.Equal("Title 1", items[0].Title);
    }

    [Fact]
    public void Descending_SortedList()
    {
        IQueryable<SimpleObject> list = SimpleObject.GetMockDataSetAsQueryable();
        SimpleObject[] items = list.SortBy("Title", false).ToArray();
        Assert.Equal(5, items[0].Id);
        Assert.Equal("Title 5", items[0].Title);
    }

    [Fact]
    public void AscendingWithSkip_SortedList()
    {
        IQueryable<SimpleObject> list = SimpleObject.GetMockDataSetAsQueryable();
        SimpleObject[] items = list.SortBy("Title").Skip(2).ToArray();
        Assert.Equal(3, items[0].Id);
        Assert.Equal("Title 3", items[0].Title);
    }

    [Fact]
    public void DescendingWithSkip_SortedList()
    {
        IQueryable<SimpleObject> list = SimpleObject.GetMockDataSetAsQueryable();
        SimpleObject[] items = list.SortBy("Title", false).Skip(2).ToArray();
        Assert.Equal(3, items[0].Id);
        Assert.Equal("Title 3", items[0].Title);
    }
}
