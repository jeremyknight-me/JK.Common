using JK.Common.Sorting;

namespace JK.Common.Tests.Sorting;

public class QuickSortTests
{
    [Fact]
    public void Sort_Test1()
    {
        var original = new int[] { 2, 5, -4, 11, 0, 18, 22, 67, 51, 6 };
        QuickSort.Sort(original, 0, original.Length - 1);
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
    public void Sort_Test2()
    {
        var original = new int[] { 9, 7, 5, 3, 10, 6 };
        QuickSort.Sort(original, 0, original.Length - 1);
        Assert.Collection(original,
            i => Assert.Equal(3, i),
            i => Assert.Equal(5, i),
            i => Assert.Equal(6, i),
            i => Assert.Equal(7, i),
            i => Assert.Equal(9, i),
            i => Assert.Equal(10, i)
        );
    }
}
