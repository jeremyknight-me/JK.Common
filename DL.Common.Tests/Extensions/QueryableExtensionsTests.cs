using System.Linq;
using DL.Common.Extensions;
using Xunit;
using System;

namespace DL.Common.Tests.Extensions
{
    public class QueryableExtensionsTests
    {
        #region SortBy(string) Tests

        [Fact]
        public void SortBy_NoSource_Exception()
        {
            IQueryable<SimpleObject> list = null;
            var ex = Assert.Throws<ArgumentNullException>(() => list.SortBy("Title"));
        }

        [Fact]
        public void SortBy_NoKeySelector_Source()
        {
            Func<SimpleObject, dynamic> key = null;
            var list = SimpleObject.GetMockDataSetAsQueryable();
            var items = list.SortBy(key);
            Assert.Equal(list, items);
        }

        [Fact]
        public void SortBy_NoPropertyName_UnsortedList()
        {
            var list = SimpleObject.GetMockDataSetAsQueryable();
            var items = list.SortBy(null).ToArray();
            Assert.Equal(1, items[0].Id);
            Assert.Equal("Title 1", items[0].Title);
        }

        [Fact]
        public void SortBy_Ascending_SortedList()
        {
            var list = SimpleObject.GetMockDataSetAsQueryable();
            var items = list.SortBy("Title").ToArray();
            Assert.Equal(1, items[0].Id);
            Assert.Equal("Title 1", items[0].Title);
        }

        [Fact]
        public void SortBy_Descending_SortedList()
        {
            var list = SimpleObject.GetMockDataSetAsQueryable();
            var items = list.SortBy("Title", false).ToArray();
            Assert.Equal(5, items[0].Id);
            Assert.Equal("Title 5", items[0].Title);
        }

        [Fact]
        public void SortBy_AscendingWithSkip_SortedList()
        {
            var list = SimpleObject.GetMockDataSetAsQueryable();
            var items = list.SortBy("Title").Skip(2).ToArray();
            Assert.Equal(3, items[0].Id);
            Assert.Equal("Title 3", items[0].Title);
        }

        [Fact]
        public void SortBy_DescendingWithSkip_SortedList()
        {
            var list = SimpleObject.GetMockDataSetAsQueryable();
            var items = list.SortBy("Title", false).Skip(2).ToArray();
            Assert.Equal(3, items[0].Id);
            Assert.Equal("Title 3", items[0].Title);
        }

        #endregion

        #region SortBy(predicate) Tests

        [Fact]
        public void SortByPredicate_NoSource_Exception()
        {
            IQueryable<SimpleObject> list = null;
            var ex = Assert.Throws<ArgumentNullException>(() => list.SortBy(x => x.Title));            
        }

        [Fact]
        public void SortByPredicate_Ascending_SortedList()
        {
            var list = SimpleObject.GetMockDataSetAsQueryable();
            var items = list.SortBy(x => x.Title).ToArray();
            Assert.Equal(1, items[0].Id);
            Assert.Equal("Title 1", items[0].Title);
        }

        [Fact]
        public void SortByPredicate_Descending_SortedList()
        {
            var list = SimpleObject.GetMockDataSetAsQueryable();
            var items = list.SortBy(x => x.Title, false).ToArray();
            Assert.Equal(5, items[0].Id);
            Assert.Equal("Title 5", items[0].Title);
        }

        [Fact]
        public void SortByPredicate_AscendingWithSkip_SortedList()
        {
            var list = SimpleObject.GetMockDataSetAsQueryable();
            var items = list.SortBy(x => x.Title).Skip(2).ToArray();
            Assert.Equal(3, items[0].Id);
            Assert.Equal("Title 3", items[0].Title);
        }

        [Fact]
        public void SortByPredicate_DescendingWithSkip_SortedList()
        {
            var list = SimpleObject.GetMockDataSetAsQueryable();
            var items = list.SortBy(x => x.Title, false).Skip(2).ToArray();
            Assert.Equal(3, items[0].Id);
            Assert.Equal("Title 3", items[0].Title);
        }

        #endregion

        #region WhereIf() Tests

        [Fact]
        public void WhereIf_NoSource_Exception()
        {
            IQueryable<SimpleObject> list = null;
            var ex = Assert.Throws<ArgumentNullException>(() => list.WhereIf(true, x => x.Id == 0));
        }

        [Fact]
        public void WhereIf_SingleTrueCondition_FilteredList()
        {
            var list = SimpleObject.GetMockDataSetAsQueryable();
            var items = list.WhereIf(true, x => x.Id == 3).ToArray();
            Assert.Equal(3, items[0].Id);
            Assert.Equal("Title 3", items[0].Title);
        }

        [Fact]
        public void WhereIf_MultipleAllTrueCondition_FilteredList()
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
        public void WhereIf_MultipleSomeTrueCondition_FilteredList()
        {
            var list = SimpleObject.GetMockDataSetAsQueryable();
            var items = list
                .WhereIf(true, x => x.Id == 3)
                .WhereIf(false, x => x.Id == 4)
                .ToArray();
            Assert.Equal(3, items[0].Id);
            Assert.Equal("Title 3", items[0].Title);
        }

        #endregion
    }
}
