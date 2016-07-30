using System;
using DL.Core.Test.Mocks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DL.Core.Test
{
    [TestClass]
    public class EquatableFacadeTests
    {
        private EquatableFacade<SimpleObject> target;

        [TestInitialize]
        public void TestInitialize()
        {
            this.target = new EquatableFacade<SimpleObject>();
            this.target.AreObjectDetailsEqual += this.AreObjectDetailsEqual;
        }

        [TestCleanup]
        public void TestCleanup()
        {
            this.target = null;
        }

        #region Equals() Tests

        [TestMethod]
        public void Equals_BothNull_ReturnsTrue()
        {
            SimpleObject left = null;
            SimpleObject right = null;

            bool actual = this.target.Equals(left, right);

            Assert.IsTrue(actual);
        }

        [TestMethod]
        public void Equals_LeftNullRightNotNull_ReturnsFalse()
        {
            SimpleObject left = null;
            SimpleObject right = new SimpleObject();

            bool actual = this.target.Equals(left, right);

            Assert.IsFalse(actual);
        }

        [TestMethod]
        public void Equals_LeftNotNullRightNull_ReturnsFalse()
        {
            SimpleObject left = new SimpleObject();
            SimpleObject right = null;

            bool actual = this.target.Equals(left, right);

            Assert.IsFalse(actual);
        }

        [TestMethod]
        public void Equals_SameReference_ReturnsTrue()
        {
            var left = new SimpleObject();
            SimpleObject right = left;

            bool actual = this.target.Equals(left, right);

            Assert.IsTrue(actual);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Equals_LeftIncorrectType_ArgumentException()
        {
            var left = new ComplexObject();
            var right = new SimpleObject();

            this.target.Equals(left, right);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Equals_RightIncorrectType_ArgumentException()
        {
            var left = new SimpleObject();
            var right = new ComplexObject();

            this.target.Equals(left, right);
        }

        [TestMethod]
        public void Equals_SameData_ReturnsTrue()
        {
            var left = new SimpleObject { Id = 1, Title = "Title 1" };
            var right = new SimpleObject { Id = 1, Title = "Title 1" };

            bool actual = this.target.Equals(left, right);

            Assert.IsTrue(actual);
        }

        [TestMethod]
        public void Equals_DifferentData_ReturnsFalse()
        {
            var left = new SimpleObject { Id = 1, Title = "Title 1" };
            var right = new SimpleObject { Id = 2, Title = "Title 2" };

            bool actual = this.target.Equals(left, right);

            Assert.IsFalse(actual);
        }

        #endregion

        private bool AreObjectDetailsEqual(SimpleObject left, SimpleObject right)
        {
            return left.Id == right.Id && left.Title == right.Title;
        }
    }
}
