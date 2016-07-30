using System;
using System.Collections.Generic;
using System.Linq;
using DL.Core.Contracts;
using DL.Core.Enums;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DL.Core.Test.Enums
{
    
    [TestClass]
    public class EnumUtilityTests
    {
        private EnumUtility utility;

        private enum ColorsWithDescriptions
        {
            [EnumLabel("Maroon")]
            Red = 1,
            [EnumLabel("Hunter Green")]
            Green = 2,
            [EnumLabel("Navy Blue")]
            Blue = 3
        }

        private enum ColorsNoDescriptions
        {
            Red = 1,
            Green = 2,
            Blue = 3
        }

        [TestInitialize]
        public void TestInitialize()
        {
            this.utility = new EnumUtility();
        }

        [TestCleanup]
        public void TestCleanup()
        {
            this.utility = null;
        }

        #region ConvertValuesToListItemData() Tests

        [TestMethod]
        public void ConvertValuesToListItemDataEnumWithoutDescription()
        {
            IEnumerable<ILabeledIdentifiable<int>> data 
                = this.utility.ConvertValuesToListItemData<ColorsNoDescriptions>();
            Assert.AreEqual(3, data.Count());
            Assert.AreEqual("Red", data.First().Label);
            Assert.AreEqual("Blue", data.Last().Label);
        }

        [TestMethod]
        public void ConvertValuesToListItemDataEnumWithDescription()
        {
            IEnumerable<ILabeledIdentifiable<int>> data 
                = this.utility.ConvertValuesToListItemData<ColorsWithDescriptions>();
            Assert.AreEqual(3, data.Count());
            Assert.AreEqual("Maroon", data.First().Label);
            Assert.AreEqual("Navy Blue", data.Last().Label);
        }

        #endregion

        #region GetByByte() Tests

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void GetByByteInvalidLowOrdinalThrowsException()
        {
            this.utility.GetByByte<ColorsNoDescriptions>(0);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void GetByByteInvalidHighOrdinalThrowsException()
        {
            this.utility.GetByByte<ColorsNoDescriptions>(5);
        }

        [TestMethod]
        public void GetByByteValidOrdinal()
        {
            var actual = this.utility.GetByByte<ColorsNoDescriptions>(2);
            Assert.AreEqual(ColorsNoDescriptions.Green, actual);
        }

        #endregion

        #region GetByte() Tests

        [TestMethod]
        public void GetByteValidEnumValue()
        {
            int actual = this.utility.GetByte(ColorsNoDescriptions.Green);
            Assert.AreEqual(2, actual);
        }

        #endregion

        #region GetByInteger() Tests

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void GetByIntegerInvalidLowOrdinalThrowsException()
        {
            this.utility.GetByInteger<ColorsNoDescriptions>(0);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void GetByIntegerInvalidHighOrdinalThrowsException()
        {
            this.utility.GetByInteger<ColorsNoDescriptions>(5);
        }

        [TestMethod]
        public void GetByIntegerValidOrdinal()
        {
            var actual = this.utility.GetByInteger<ColorsNoDescriptions>(2);
            Assert.AreEqual(ColorsNoDescriptions.Green, actual);
        }

        #endregion

        #region GetInteger() Tests

        [TestMethod]
        public void GetIntegerValidEnumValue()
        {
            int actual = this.utility.GetInteger(ColorsNoDescriptions.Green);
            Assert.AreEqual(2, actual);
        }

        #endregion

        #region IsValidEnumByte() Tests

        [TestMethod]
        public void IsValidEnumByteValidNumberTrue()
        {
            bool actual = this.utility.IsValidEnumByte<ColorsNoDescriptions>(2);
            Assert.IsTrue(actual);
        }

        [TestMethod]
        public void IsValidEnumByteInvalidNumberFalse()
        {
            bool actual = this.utility.IsValidEnumByte<ColorsNoDescriptions>(5);
            Assert.IsFalse(actual);
        }

        [TestMethod]
        public void IsValidEnumByteZeroFalse()
        {
            bool actual = this.utility.IsValidEnumByte<ColorsNoDescriptions>(0);
            Assert.IsFalse(actual);
        }

        #endregion

        #region IsValidEnumInteger() Tests

        [TestMethod]
        public void IsValidEnumIntegerValidNumberTrue()
        {
            bool actual = this.utility.IsValidEnumInteger<ColorsNoDescriptions>(2);
            Assert.IsTrue(actual);
        }

        [TestMethod]
        public void IsValidEnumIntegerInvalidNumberFalse()
        {
            bool actual = this.utility.IsValidEnumInteger<ColorsNoDescriptions>(5);
            Assert.IsFalse(actual);
        }

        [TestMethod]
        public void IsValidEnumIntegerNegativeNumberFalse()
        {
            bool actual = this.utility.IsValidEnumInteger<ColorsNoDescriptions>(-1);
            Assert.IsFalse(actual);
        }

        [TestMethod]
        public void IsValidEnumIntegerZeroFalse()
        {
            bool actual = this.utility.IsValidEnumInteger<ColorsNoDescriptions>(0);
            Assert.IsFalse(actual);
        }

        #endregion

        #region GetTitle() Tests

        [TestMethod]
        public void GetTitleEnumWitDescriptions()
        {
            string actual = this.utility.GetTitle(ColorsWithDescriptions.Blue);
            Assert.AreEqual("Navy Blue", actual);
        }

        [TestMethod]
        public void GetTitleEnumWithoutDescriptions()
        {
            string actual = this.utility.GetTitle(ColorsNoDescriptions.Blue);
            Assert.AreEqual("Blue", actual);
        }

        [TestMethod]
        public void GetTitleByIntegerEnumWitDescriptions()
        {
            string actual = this.utility.GetTitle<ColorsWithDescriptions>(3);
            Assert.AreEqual("Navy Blue", actual);
        }

        [TestMethod]
        public void GetTitleByIntegerEnumWithoutDescriptions()
        {
            string actual = this.utility.GetTitle<ColorsNoDescriptions>(3);
            Assert.AreEqual("Blue", actual);
        }

        #endregion
    }
}
