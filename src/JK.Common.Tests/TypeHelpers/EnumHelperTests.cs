using JK.Common.TypeHelpers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Xunit;

namespace JK.Common.Tests.TypeHelpers
{
    public class EnumHelperTests
    {
        /*
        private enum Colors
        {
            Red = 1,
            Green = 2,
            Blue = 3
        }

        private enum ColorsWithNames
        {
            [Display(Name = "Maroon")]
            Red = 1,
            [Display(Name = "Forest Green")]
            Green = 2,
            [Display(Name = "Navy Blue")]
            Blue = 3
        }
        */

        public enum Colors
        {
            Green = 2,
            [Display(Name = "Cyan")]
            Blue = 3
        }

        #region ConvertValuesToListItemData() Tests

        [Fact]
        public void ConvertToListItems_Test()
        {
            var data = EnumHelper.ConvertToListItems(typeof(Colors));
            Assert.Equal(2, data.Count());
            Assert.Equal("Green", data.First().Text);
            Assert.Equal("Cyan", data.Last().Text);
        }

        #endregion

        #region GetAttribute<T>() Tests

        [Fact]
        public void GetAttribute_Exists_Attribute()
        {
            var actual = new EnumHelper().GetAttribute<DisplayAttribute>(Colors.Blue);
            Assert.NotNull(actual);
            Assert.IsType<DisplayAttribute>(actual);
        }

        [Fact]
        public void GetAttribute_DoesNotExists_Null()
        {
            var actual = new EnumHelper().GetAttribute<DisplayAttribute>(Colors.Green);
            Assert.Null(actual);
        }

        #endregion

        #region GetByByte() Tests

        [Fact]
        public void GetByByte_NonEnumValue_ArgumentException()
        {
            var ex = Assert.Throws<ArgumentException>(() => new EnumHelper().GetByByte<byte>(0));
            Assert.Equal("T must be an enumerated type", ex.Message);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(5)]
        public void GetByByte_InvalidValue(byte invalidValue)
        {
            var ex = Assert.Throws<ArgumentOutOfRangeException>(() => new EnumHelper().GetByByte<Colors>(invalidValue));
        }

        [Fact]
        public void GetByByte_ValidOrdinal()
        {
            var actual = new EnumHelper().GetByByte<Colors>(2);
            Assert.Equal(Colors.Green, actual);
        }

        #endregion

        #region GetByInteger() Tests

        [Fact]
        public void GetByInteger_NonEnumValue_ArgumentException()
        {
            var ex = Assert.Throws<ArgumentException>(() => new EnumHelper().GetByInteger<int>(0));
            Assert.Equal("T must be an enumerated type", ex.Message);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(5)]
        public void GetByInteger_InvalidValue(int invalidValue)
        {
            var ex = Assert.Throws<ArgumentOutOfRangeException>(() => new EnumHelper().GetByInteger<Colors>(invalidValue));
        }

        [Fact]
        public void GetByInteger_ValidOrdinal()
        {
            var actual = new EnumHelper().GetByInteger<Colors>(2);
            Assert.Equal(Colors.Green, actual);
        }

        #endregion

        #region GetDisplayName() Tests

        [Theory]
        [MemberData(nameof(BuildDataGetDisplayName))]
        public void GetDisplayName_(Colors enumValue, string expected)
        {
            var actual = new EnumHelper().GetDisplayName(enumValue);
            Assert.Equal(expected, actual);
        }

        public static IEnumerable<object[]> BuildDataGetDisplayName()
        {
            yield return new object[] { Colors.Blue, "Cyan" };
            yield return new object[] { Colors.Green, "Green" };
        }

        #endregion

        #region GetByte(T) Tests

        [Fact]
        public void GetByte_ValidEnumValue()
        {
            byte actual = new EnumHelper().GetByte(Colors.Green);
            Assert.Equal(2, actual);
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
            int? actual = new EnumHelper().GetInteger((Colors?)Colors.Green);
            Assert.Equal(2, actual);
        }

        #endregion
    }
}
