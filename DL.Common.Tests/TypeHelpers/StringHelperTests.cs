using DL.Common.TypeHelpers;
using Xunit;

namespace DL.Common.Tests.TypeHelpers
{
    public class StringUtilityTests
    {
        #region GetNullableDecimal() Tests

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("  ")]
        [InlineData("abc")]
        public void GetNullableDecimal_EmptyOrAlpha_Null(string value)
        {
            var target = new StringHelper();
            var actual = target.GetNullableDecimal(value);
            Assert.Null(actual);
        }

        [Theory]
        [InlineData("123", 123)]
        [InlineData("123.456", 123.456)]
        public void GetNullableDecimal_Numeric_Decimal(string input, decimal expected)
        {
            var target = new StringHelper();
            var actual = target.GetNullableDecimal(input);
            Assert.Equal(expected, actual);
        }

        #endregion

        #region GetNullableInteger() Tests

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("  ")]
        [InlineData("abc")]
        [InlineData("123.456")]
        public void GetNullableInteger_EmptyAlphaOrDecimal_Null(string value)
        {
            var target = new StringHelper();
            var actual = target.GetNullableInteger(value);
            Assert.Null(actual);
        }

        [Fact]
        public void GetNullableInteger_Numeric_Int()
        {
            var target = new StringHelper();
            var actual = target.GetNullableInteger("123");
            Assert.Equal(123, actual.Value);
        }

        #endregion

        #region RemoveUSCurrencyFormat() Tests

        [Theory]
        [InlineData("$1,000,000.00", "1000000.00")]
        [InlineData("1000.00", "1000.00")]
        [InlineData("$,", "0")]
        public void RemoveUnitedStatesCurrencyFormat_WithCharacters(string input, string expected)
        {
            var target = new StringHelper();
            var actual = target.RemoveUnitedStatesCurrencyFormat(input);
            Assert.Equal(expected, actual);
        }

        #endregion

        #region Reverse() Tests

        [Fact]
        public void Reverse_Test()
        {
            const string s = "Sample Text";
            var target = new StringHelper();
            string actual = target.Reverse(s);
            Assert.Equal("txeT elpmaS", actual);
        }

        #endregion

        #region Right() Tests

        [Theory]
        [InlineData("", 2, "")]
        [InlineData("Test", 2, "st")]
        [InlineData("Test", 4, "Test")]
        [InlineData("Test", 6, "Test")]
        public void Right_Theories(string input, int length, string expected)
        {
            var sut = new StringHelper();
            var actual = sut.Right(input, length);
            Assert.Equal(expected, actual);
        }

        #endregion

        #region StripXml() Tests

        [Fact]
        public void StripXml_Test()
        {
            const string s = "<xml>Inner Text</xml>";
            var target = new StringHelper();
            string actual = target.StripXml(s);
            Assert.Equal("Inner Text", actual);
        }

        #endregion  
    }
}
