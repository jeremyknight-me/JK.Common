using System.Collections.Generic;
using JK.Common.Extensions;

namespace JK.Common.Tests.Extensions;

public class CollectionExtensionsTests
{
    [Fact]
    public void ICollectionT_Null_Exception()
    {
        ICollection<int> items = null;
        Assert.Throws<NullReferenceException>(() => items.HasItems());
    }

    [Fact]
    public void ICollectionT_HasItems_NoItems_False()
    {
        ICollection<int> items = Array.Empty<int>();
        Assert.False(items.HasItems());
    }

    [Fact]
    public void ICollectionT_HasItems_Items_True()
    {
        ICollection<int> items = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
        Assert.True(items.HasItems());
    }

    [Fact]
    public void IReadOnlyCollectionT_Null_Exception()
    {
        IReadOnlyCollection<int> items = null;
        Assert.Throws<NullReferenceException>(() => items.HasItems());
    }

    [Fact]
    public void IReadOnlyCollectionT_HasItems_NoItems_False()
    {
        IReadOnlyCollection<int> items = Array.Empty<int>();
        Assert.False(items.HasItems());
    }

    [Fact]
    public void IReadOnlyCollectionT_HasItems_Items_True()
    {
        IReadOnlyCollection<int> items = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
        Assert.True(items.HasItems());
    }
}
