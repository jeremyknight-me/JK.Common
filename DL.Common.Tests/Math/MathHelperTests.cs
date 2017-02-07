using DL.Common.Math;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DL.Common.Tests.Math
{
    [TestClass]
    public class MathHelperTests
    {
        private MathHelper utility;

        [TestInitialize]
        public void TestInitialize()
        {
            this.utility = new MathHelper();
        }

        [TestCleanup]
        public void TestCleanup()
        {
            this.utility = null;
        }

        #region IsPrime() Tests

        [TestMethod]
        public void IsPrime_1_False()
        {
            bool actual = this.utility.IsPrime(1);
            Assert.IsFalse(actual);
        }

        [TestMethod]
        public void IsPrime_2_True()
        {
            bool actual = this.utility.IsPrime(2);
            Assert.IsTrue(actual);
        }

        [TestMethod]
        public void IsPrime_8_False()
        {
            bool actual = this.utility.IsPrime(8);
            Assert.IsFalse(actual);
        }

        [TestMethod]
        public void IsPrime_17_True()
        {
            bool actual = this.utility.IsPrime(17);
            Assert.IsTrue(actual);
        } 

        [TestMethod]
        public void IsPrime_6857_True()
        {
            bool actual = this.utility.IsPrime(6857);
            Assert.IsTrue(actual);
        } 

        #endregion
    }
}
