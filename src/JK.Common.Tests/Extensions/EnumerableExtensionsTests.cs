using System.Linq;
using JK.Common.Extensions;

namespace JK.Common.Tests.Extensions;

public class EnumerableExtensionsTests
{
#if (!NET6_0_OR_GREATER)
    #region DistinctBy() Tests

        [Fact]
        public void DistinctByTestDate()
        {
            var list = Enumerable.Range(0, 200).Select(i => new
            {
                Index = i,
                Date = DateTime.Today.AddDays(i % 4)
            }).ToList();

            var distinctList = list.DistinctBy(l => l.Date).ToList();

            Assert.Equal(4, distinctList.Count);

            Assert.Equal(0, distinctList[0].Index);
            Assert.Equal(1, distinctList[1].Index);
            Assert.Equal(2, distinctList[2].Index);
            Assert.Equal(3, distinctList[3].Index);

            Assert.Equal(DateTime.Today, distinctList[0].Date);
            Assert.Equal(DateTime.Today.AddDays(1), distinctList[1].Date);
            Assert.Equal(DateTime.Today.AddDays(2), distinctList[2].Date);
            Assert.Equal(DateTime.Today.AddDays(3), distinctList[3].Date);

            Assert.Equal(200, list.Count);
        }

        [Fact]
        public void DistinctByTestInt()
        {
            var list = Enumerable.Range(0, 200).Select(i => new
            {
                Index = i % 4,
                Date = DateTime.Today.AddDays(i)
            }).ToList();

            var distinctList = list.DistinctBy(l => l.Index).ToList();

            Assert.Equal(4, distinctList.Count);

            Assert.Equal(0, distinctList[0].Index);
            Assert.Equal(1, distinctList[1].Index);
            Assert.Equal(2, distinctList[2].Index);
            Assert.Equal(3, distinctList[3].Index);

            Assert.Equal(DateTime.Today, distinctList[0].Date);
            Assert.Equal(DateTime.Today.AddDays(1), distinctList[1].Date);
            Assert.Equal(DateTime.Today.AddDays(2), distinctList[2].Date);
            Assert.Equal(DateTime.Today.AddDays(3), distinctList[3].Date);

            Assert.Equal(200, list.Count);
        }

        [Fact]
        public void TestStructs()
        {
            var list = Enumerable.Range(0, 200)
                .Select(i => new EqualityStructTester(i, DateTime.Today.AddDays(i % 4)))
                .ToList();

            var distinctDateList = list.DistinctBy(e => e.Date).ToList();
            var distinctIntList = list.DistinctBy(e => e.Index).ToList();

            Assert.Equal(4, distinctDateList.Count);
            Assert.Equal(200, distinctIntList.Count);
        }

        [Fact]
        public void TestClasses()
        {
            var list = Enumerable.Range(0, 200)
                .Select(i => new EqualityClassTester(i, DateTime.Today.AddDays(i % 4)))
                .ToList();

            var distinctDateList = list.DistinctBy(e => e.Date).ToList();
            var distinctIntList = list.DistinctBy(e => e.Index).ToList();

            Assert.Equal(4, distinctDateList.Count);
            Assert.Equal(200, distinctIntList.Count);
        }

    #endregion
#endif

    #region AsIndexedEnumerable() Tests

    [Fact]
    public void AsIndexedEnumerable_Alphabet()
    {
        var list = "ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray();
        var indexedList = list.AsIndexedEnumerable();
        Assert.Equal("A", indexedList.FirstOrDefault(x => x.index == 0).item.ToString());
        Assert.Equal("Z", indexedList.FirstOrDefault(x => x.index == 25).item.ToString());
    }

    #endregion

    private struct EqualityStructTester
    {
        public readonly int Index;
        public readonly DateTime Date;

        public EqualityStructTester(int index, DateTime date) : this()
        {
            this.Index = index;
            this.Date = date;
        }
    }

    private class EqualityClassTester
    {
        public readonly int Index;
        public readonly DateTime Date;

        public EqualityClassTester()
        {
        }

        public EqualityClassTester(int index, DateTime date) : this()
        {
            this.Index = index;
            this.Date = date;
        }
    }
}
