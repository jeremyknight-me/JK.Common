using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DL.Core.Math;

namespace DL.Core.Test.Math
{
    [TestClass]
    public class MathUtilityTests
    {
        private MathUtility utility;

        [TestInitialize]
        public void TestInitialize()
        {
            this.utility = new MathUtility();
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
