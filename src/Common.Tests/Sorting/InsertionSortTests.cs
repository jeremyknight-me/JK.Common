using JK.Common.Sorting;

namespace JK.Common.Tests.Sorting;

public class InsertionSortTests
{
    [Fact]
    public void Sort_IntArray_Test()
    {
        int[] original = [2, 5, -4, 11, 0, 18, 22, 67, 51, 6];
        InsertionSort.Sort(original);
        Assert.Collection(original,
            i => Assert.Equal(-4, i),
            i => Assert.Equal(0, i),
            i => Assert.Equal(2, i),
            i => Assert.Equal(5, i),
            i => Assert.Equal(6, i),
            i => Assert.Equal(11, i),
            i => Assert.Equal(18, i),
            i => Assert.Equal(22, i),
            i => Assert.Equal(51, i),
            i => Assert.Equal(67, i)
        );
    }

    [Fact]
    public void Sort_StringList_Test()
    {
        List<string> original = ["i", "g", "e", "c", "f"];
        InsertionSort.Sort(original);
        Assert.Collection(original,
            i => Assert.Equal("c", i),
            i => Assert.Equal("e", i),
            i => Assert.Equal("f", i),
            i => Assert.Equal("g", i),
            i => Assert.Equal("i", i)
        );
    }
}
