using System;
using System.Linq;
using DL.Core.Linq;
using DL.Core.Test.Mocks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DL.Core.Test.Linq
{
    [TestClass]
    public class LinqExtensionsTests
    {
        private IQueryable<SimpleObject> list;
            
        [TestInitialize]
        public void TestInitialize()
        {
            this.list = SimpleObject.GetMockDataSetAsQueryable();
        }

        [TestCleanup]
        public void TestCleanup()
        {
            this.list = null;
        }

        #region SortBy(string) Tests

        [TestMethod]
        [ExpectedException(typeof (ArgumentNullException))]
        public void SortBy_NoSource_Exception()
        {
            this.list = null;
            this.list.SortBy("Title");
        }

        [TestMethod]
        public void SortBy_NoPropertyName_UnsortedList()
        {
            var items = this.list.SortBy(null).ToArray();
            Assert.AreEqual(1, items[0].Id);
            Assert.AreEqual("Title 1", items[0].Title);
        }

        [TestMethod]
        public void SortBy_Ascending_SortedList()
        {
            var items = this.list.SortBy("Title").ToArray();
            Assert.AreEqual(1, items[0].Id);
            Assert.AreEqual("Title 1", items[0].Title);
        }

        [TestMethod]
        public void SortBy_Descending_SortedList()
        {
            var items = this.list.SortBy("Title", false).ToArray();
            Assert.AreEqual(5, items[0].Id);
            Assert.AreEqual("Title 5", items[0].Title);
        }

        [TestMethod]
        public void SortBy_AscendingWithSkip_SortedList()
        {
            var items = this.list.SortBy("Title").Skip(2).ToArray();
            Assert.AreEqual(3, items[0].Id);
            Assert.AreEqual("Title 3", items[0].Title);
        }

        [TestMethod]
        public void SortBy_DescendingWithSkip_SortedList()
        {
            var items = this.list.SortBy("Title", false).Skip(2).ToArray();
            Assert.AreEqual(3, items[0].Id);
            Assert.AreEqual("Title 3", items[0].Title);
        }

        #endregion

        #region SortBy(predicate) Tests

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void SortByPredicate_NoSource_Exception()
        {
            this.list = null;
            this.list.SortBy(x => x.Title);
        }

        [TestMethod]
        public void SortByPredicate_Ascending_SortedList()
        {
            var items = this.list.SortBy(x => x.Title).ToArray();
            Assert.AreEqual(1, items[0].Id);
            Assert.AreEqual("Title 1", items[0].Title);
        }

        [TestMethod]
        public void SortByPredicate_Descending_SortedList()
        {
            var items = this.list.SortBy(x => x.Title, false).ToArray();
            Assert.AreEqual(5, items[0].Id);
            Assert.AreEqual("Title 5", items[0].Title);
        }

        [TestMethod]
        public void SortByPredicate_AscendingWithSkip_SortedList()
        {
            var items = this.list.SortBy(x => x.Title).Skip(2).ToArray();
            Assert.AreEqual(3, items[0].Id);
            Assert.AreEqual("Title 3", items[0].Title);
        }

        [TestMethod]
        public void SortByPredicate_DescendingWithSkip_SortedList()
        {
            var items = this.list.SortBy(x => x.Title, false).Skip(2).ToArray();
            Assert.AreEqual(3, items[0].Id);
            Assert.AreEqual("Title 3", items[0].Title);
        }

        #endregion

        #region WhereIf() Tests

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void WhereIf_NoSource_Exception()
        {
            this.list = null;
            this.list.WhereIf(true, x => x.Id == 0);
        }

        [TestMethod]
        public void WhereIf_SingleTrueCondition_FilteredList()
        {
            var items = this.list.WhereIf(true, x => x.Id == 3).ToArray();
            Assert.AreEqual(3, items[0].Id);
            Assert.AreEqual("Title 3", items[0].Title);
        }

        [TestMethod]
        public void WhereIf_MultipleAllTrueCondition_FilteredList()
        {
            var items = this.list
                .WhereIf(true, x => x.Id == 3)
                .WhereIf(true, x => x.Title == "Title 3")
                .ToArray();
            Assert.AreEqual(3, items[0].Id);
            Assert.AreEqual("Title 3", items[0].Title);
        }

        [TestMethod]
        public void WhereIf_MultipleSomeTrueCondition_FilteredList()
        {
            var items = this.list
                .WhereIf(true, x => x.Id == 3)
                .WhereIf(false, x => x.Id == 4)
                .ToArray();
            Assert.AreEqual(3, items[0].Id);
            Assert.AreEqual("Title 3", items[0].Title);
        }

        #endregion
    }
}
