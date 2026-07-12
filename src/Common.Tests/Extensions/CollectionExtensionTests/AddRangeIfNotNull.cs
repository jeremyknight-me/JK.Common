using JK.Common.Extensions;

namespace JK.Common.Tests.Extensions.CollectionExtensionTests;

public class AddRangeIfNotNull
{
    [Fact]
    public void NullCollection_Throws()
    {
        List<object> list = null;
        Assert.Throws<ArgumentNullException>(() => list.AddRangeIfNotNull([]));
    }

    [Fact]
    public void FilledCollection_NullItems_NoChange()
    {
        List<int> list = [1, 2];
        list.AddRangeIfNotNull(null);

        Assert.Equal(2, list.Count);
        Assert.Collection(list,
            i => Assert.Equal(1, i),
            i => Assert.Equal(2, i));
    }

    [Fact]
    public void FilledCollection_EmptyItems_NoChange()
    {
        List<int> list = [1, 2];
        list.AddRangeIfNotNull([]);

        Assert.Equal(2, list.Count);
        Assert.Collection(list,
            i => Assert.Equal(1, i),
            i => Assert.Equal(2, i));
    }

    [Fact]
    public void FilledCollection_NonNullItems_ItemsAdded()
    {
        List<int> list = [1, 2];
        list.AddRangeIfNotNull([3, 4]);

        Assert.Equal(4, list.Count);
        Assert.Collection(list,
            i => Assert.Equal(1, i),
            i => Assert.Equal(2, i),
            i => Assert.Equal(3, i),
            i => Assert.Equal(4, i));
    }
}
