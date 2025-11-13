using JK.Common.Extensions;

namespace JK.Common.Tests.Extensions.CollectionExtensionTests;

public class AddIfNotNull
{
    [Fact]
    public void NullCollection_Throws()
    {
        List<int> list = null;
        Assert.Throws<ArgumentNullException>(() => list.AddIfNotNull(0));
    }

    [Fact]
    public void FilledCollection_NullItem_NoChange()
    {
        List<string> list = ["a", "b"];

        list.AddIfNotNull(null);

        Assert.Equal(2, list.Count);
        Assert.Collection(list,
            i => Assert.Equal("a", i),
            i => Assert.Equal("b", i));
    }

    [Fact]
    public void FilledCollection_NonNullItem_ItemAdded()
    {
        var list = new List<int> { 1, 2 };

        list.AddIfNotNull(3);

        Assert.Equal(3, list.Count);
        Assert.Collection(list,
            i => Assert.Equal(1, i),
            i => Assert.Equal(2, i),
            i => Assert.Equal(3, i));
    }
}
