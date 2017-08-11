using DL.Common.TypeHelpers;
using System;
using Xunit;

namespace DL.Common.Tests.TypeHelpers
{
    public class EnumHelperTests
    {
        private enum Colors
        {
            Green = 2
        }

        #region GetByInteger() Tests
        
        [Fact]
        public void GetByInteger_NonEnumValue_ArgumentException()
        {
            var ex = Assert.Throws<ArgumentException>(() => new EnumHelper().GetByInteger<int>(0));
            Assert.Equal("T must be an enumerated type", ex.Message);
        }

        [Fact]
        public void GetByInteger_InvalidLowOrdinal_ArgumentOutOfRangeException()
        {
            var ex = Assert.Throws<ArgumentOutOfRangeException>(() => new EnumHelper().GetByInteger<Colors>(0));
        }

        [Fact]
        public void GetByInteger_InvalidHighOrdinal_ArgumentOutOfRangeException()
        {
            var ex = Assert.Throws<ArgumentOutOfRangeException>(() => new EnumHelper().GetByInteger<Colors>(5));
        }

        [Fact]
        public void GetByInteger_ValidOrdinal()
        {
            var actual = new EnumHelper().GetByInteger<Colors>(2);
            Assert.Equal(Colors.Green, actual);
        }

        #endregion

        #region GetInteger(T) Tests

        [Fact]
        public void GetInteger_ValidEnumValue()
        {
            int actual = new EnumHelper().GetInteger(Colors.Green);
            Assert.Equal(2, actual);
        }

        #endregion

        #region GetInteger(T?) Tests

        [Fact]
        public void GetInteger_NullableEnumNull_Null()
        {
            int? actual = new EnumHelper().GetInteger((Colors?)null);
            Assert.Null(actual);
        }

        [Fact]
        public void GetInteger_NullableEnumValue_Integer()
        {
            Colors? color = Colors.Green;
            int? actual = new EnumHelper().GetInteger(color);
            Assert.Equal(2, actual);
        }

        #endregion
    }
}
