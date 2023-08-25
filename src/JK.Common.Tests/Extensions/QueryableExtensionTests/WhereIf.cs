using System.Linq;
using JK.Common.Extensions;

namespace JK.Common.Tests.Extensions.QueryableExtensionTests;

public class WhereIf
{
    [Fact]
    public void NoSource_Exception()
    {
        IQueryable<SimpleObject> list = null;
        var ex = Assert.Throws<ArgumentNullException>(() => list.WhereIf(true, x => x.Id == 0));
    }

    [Fact]
    public void SingleTrueCondition_FilteredList()
    {
        var list = SimpleObject.GetMockDataSetAsQueryable();
        var items = list.WhereIf(true, x => x.Id == 3).ToArray();
        Assert.Equal(3, items[0].Id);
        Assert.Equal("Title 3", items[0].Title);
    }

    [Fact]
    public void MultipleAllTrueCondition_FilteredList()
    {
        var list = SimpleObject.GetMockDataSetAsQueryable();
        var items = list
            .WhereIf(true, x => x.Id == 3)
            .WhereIf(true, x => x.Title == "Title 3")
            .ToArray();
        Assert.Equal(3, items[0].Id);
        Assert.Equal("Title 3", items[0].Title);
    }

    [Fact]
    public void MultipleSomeTrueCondition_FilteredList()
    {
        var list = SimpleObject.GetMockDataSetAsQueryable();
        var items = list
            .WhereIf(true, x => x.Id == 3)
            .WhereIf(false, x => x.Id == 4)
            .ToArray();
        Assert.Equal(3, items[0].Id);
        Assert.Equal("Title 3", items[0].Title);
    }
}
