using DL.Common.TypeHelpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace DL.Common.Tests.TypeHelpers
{
    [TestClass]
    public class EnumHelperTests
    {
        private enum Colors
        {
            Green = 2
        }

        #region GetByInteger() Tests

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void GetByInteger_NonEnumValue_Exception()
        {
            new EnumHelper().GetByInteger<int>(0);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void GetByInteger_InvalidLowOrdinal_Exception()
        {
            new EnumHelper().GetByInteger<Colors>(0);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void GetByInteger_InvalidHighOrdinal_Exception()
        {
            new EnumHelper().GetByInteger<Colors>(5);
        }

        [TestMethod]
        public void GetByInteger_ValidOrdinal()
        {
            var actual = new EnumHelper().GetByInteger<Colors>(2);
            Assert.AreEqual(Colors.Green, actual);
        }

        #endregion

        #region GetInteger(T) Tests

        [TestMethod]
        public void GetInteger_ValidEnumValue()
        {
            int actual = new EnumHelper().GetInteger(Colors.Green);
            Assert.AreEqual(2, actual);
        }

        #endregion

        #region GetInteger(T?) Tests

        [TestMethod]
        public void GetInteger_NullableEnumNull_Null()
        {
            int? actual = new EnumHelper().GetInteger((Colors?)null);
            Assert.IsNull(actual);
        }

        [TestMethod]
        public void GetInteger_NullableEnumValue_Integer()
        {
            Colors? color = Colors.Green;
            int? actual = new EnumHelper().GetInteger(color);
            Assert.AreEqual(2, actual);
        }

        #endregion
    }
}
