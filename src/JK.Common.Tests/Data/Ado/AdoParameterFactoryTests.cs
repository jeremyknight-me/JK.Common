using System;
using System.Data;
using JK.Common.Data.Ado;
using Moq;
using Xunit;

namespace JK.Common.Tests.Data.Ado
{
    public class AdoParameterFactoryTests
    {
        private const string parameterName = "test";

        [Fact]
        public void Make_NameAndType_Equal()
        {
            var databaseType = DbType.String;
            var target = this.GetFactory();
            var parameter = target.Make(parameterName, databaseType);
            Assert.Equal("test", parameter.ParameterName);
            Assert.Equal(DbType.String, parameter.DbType);
        }

        #region Boolean Tests

        [Theory]
        [InlineData(true, DbType.Boolean, true)]
        [InlineData(false, DbType.Boolean, false)]
        public void Make_Boolean(bool parameterValue, DbType expectedType, object expectedValue )
        {
            var target = this.GetFactory();
            var parameter = target.Make(parameterName, parameterValue);

            Assert.Equal("test", parameter.ParameterName);
            Assert.Equal(expectedType, parameter.DbType);
            Assert.Equal(expectedValue, parameter.Value);
        }

        [Fact]
        public void Make_NameAndNullableBooleanNonNull_Equal()
        {
            bool? parameterValue = true;
            var target = this.GetFactory();
            var parameter = target.Make(parameterName, parameterValue);

            Assert.Equal("test", parameter.ParameterName);
            Assert.Equal(DbType.Boolean, parameter.DbType);
            Assert.Equal(true, parameter.Value);
        }

        [Fact]
        public void Make_NameAndNullableBooleanNull_Equal()
        {
            bool? parameterValue = null;
            var target = this.GetFactory();
            var parameter = target.Make(parameterName, parameterValue);

            Assert.Equal("test", parameter.ParameterName);
            Assert.Equal(DbType.Boolean, parameter.DbType);
            Assert.Equal(DBNull.Value, parameter.Value);
        }

        #endregion

        #region DateTime Tests

        [Fact]
        public void Make_NameAndDateTimeNotNull_Equal()
        {
            var parameterValue = DateTime.Now;
            var target = this.GetFactory();
            var parameter = target.Make(parameterName, parameterValue);
            Assert.Equal("test", parameter.ParameterName);
            Assert.Equal(DbType.DateTime, parameter.DbType);
            Assert.Equal(parameterValue, parameter.Value);
        }

        [Fact]
        public void Make_NameAndNullableDateTimeNotNull_Equal()
        {
            DateTime? parameterValue = DateTime.Now;
            var target = this.GetFactory();
            var parameter = target.Make(parameterName, parameterValue);
            Assert.Equal("test", parameter.ParameterName);
            Assert.Equal(DbType.DateTime, parameter.DbType);
            Assert.Equal(parameterValue, parameter.Value);
        }

        [Fact]
        public void Make_NameAndNullableDateTimeNull_Equal()
        {
            DateTime? parameterValue = null;
            var target = this.GetFactory();
            var parameter = target.Make(parameterName, parameterValue);
            Assert.Equal("test", parameter.ParameterName);
            Assert.Equal(DbType.DateTime, parameter.DbType);
            Assert.Equal(DBNull.Value, parameter.Value);
        }

        #endregion

        #region DateTimeOffset Tests

        [Fact]
        public void Make_NameAndDateTimeOffsetNotNull_Equal()
        {
            var parameterValue = DateTimeOffset.Now;
            var target = this.GetFactory();
            var parameter = target.Make(parameterName, parameterValue);
            Assert.Equal("test", parameter.ParameterName);
            Assert.Equal(DbType.DateTimeOffset, parameter.DbType);
            Assert.Equal(parameterValue, parameter.Value);
        }

        [Fact]
        public void Make_NameAndNullableDateTimeOffsetNotNull_Equal()
        {
            DateTimeOffset? parameterValue = DateTimeOffset.Now;
            var target = this.GetFactory();
            var parameter = target.Make(parameterName, parameterValue);
            Assert.Equal("test", parameter.ParameterName);
            Assert.Equal(DbType.DateTimeOffset, parameter.DbType);
            Assert.Equal(parameterValue, parameter.Value);
        }

        [Fact]
        public void Make_NameAndNullableDateTimeOffsetNull_Equal()
        {
            DateTimeOffset? parameterValue = null;
            var target = this.GetFactory();
            var parameter = target.Make(parameterName, parameterValue);
            Assert.Equal("test", parameter.ParameterName);
            Assert.Equal(DbType.DateTimeOffset, parameter.DbType);
            Assert.Equal(DBNull.Value, parameter.Value);
        }

        #endregion

        #region Decimal Tests

        [Fact]
        public void Make_NameAndDecimalNonZero_Equal()
        {
            var parameterValue = 1m;
            var target = this.GetFactory();
            var parameter = target.Make(parameterName, parameterValue);
            Assert.Equal("test", parameter.ParameterName);
            Assert.Equal(DbType.Decimal, parameter.DbType);
            Assert.Equal(1m, parameter.Value);
        }

        [Fact]
        public void Make_NameAndDecimalZero_Equal()
        {
            var parameterValue = 0m;
            var target = this.GetFactory();
            var parameter = target.Make(parameterName, parameterValue);
            Assert.Equal("test", parameter.ParameterName);
            Assert.Equal(DbType.Decimal, parameter.DbType);
            Assert.Equal(0m, parameter.Value);
        }

        [Fact]
        public void Make_NameAndNullableDecimalNonNull_Equal()
        {
            decimal? parameterValue = 1;
            var target = this.GetFactory();
            var parameter = target.Make(parameterName, parameterValue);
            Assert.Equal("test", parameter.ParameterName);
            Assert.Equal(DbType.Decimal, parameter.DbType);
            Assert.Equal(1m, parameter.Value);
        }

        [Fact]
        public void Make_NameAndNullableDecimalNull_Equal()
        {
            decimal? parameterValue = null;
            var target = this.GetFactory();
            var parameter = target.Make(parameterName, parameterValue);
            Assert.Equal("test", parameter.ParameterName);
            Assert.Equal(DbType.Decimal, parameter.DbType);
            Assert.Equal(DBNull.Value, parameter.Value);
        }

        #endregion

        #region Double Tests

        [Fact]
        public void Make_NameAndDoubleNonZero_Equal()
        {
            double parameterValue = 1;
            var target = this.GetFactory();
            var parameter = target.Make(parameterName, parameterValue);
            Assert.Equal("test", parameter.ParameterName);
            Assert.Equal(DbType.Double, parameter.DbType);
            Assert.Equal(1D, parameter.Value);
        }

        [Fact]
        public void Make_NameAndDoubleZero_Equal()
        {
            double parameterValue = 0;
            var target = this.GetFactory();
            var parameter = target.Make(parameterName, parameterValue);
            Assert.Equal("test", parameter.ParameterName);
            Assert.Equal(DbType.Double, parameter.DbType);
            Assert.Equal(0D, parameter.Value);
        }

        [Fact]
        public void Make_NameAndNullableDoubleNonNull_Equal()
        {
            double? parameterValue = 1;
            var target = this.GetFactory();
            var parameter = target.Make(parameterName, parameterValue);
            Assert.Equal("test", parameter.ParameterName);
            Assert.Equal(DbType.Double, parameter.DbType);
            Assert.Equal(1D, parameter.Value);
        }

        [Fact]
        public void Make_NameAndNullableDoubleNull_Equal()
        {
            double? parameterValue = null;
            var target = this.GetFactory();
            var parameter = target.Make(parameterName, parameterValue);
            Assert.Equal("test", parameter.ParameterName);
            Assert.Equal(DbType.Double, parameter.DbType);
            Assert.Equal(DBNull.Value, parameter.Value);
        }

        #endregion

        #region Guid Tests

        [Fact]
        public void Make_NameAndGuidNotNull_Equal()
        {
            var parameterValue = Guid.NewGuid();
            var target = this.GetFactory();
            var parameter = target.Make(parameterName, parameterValue);
            Assert.Equal("test", parameter.ParameterName);
            Assert.Equal(DbType.Guid, parameter.DbType);
            Assert.Equal(parameterValue, parameter.Value);
        }

        [Fact]
        public void Make_NameAndNullableGuidNotNull_Equal()
        {
            Guid? parameterValue = Guid.NewGuid();
            var target = this.GetFactory();
            var parameter = target.Make(parameterName, parameterValue);
            Assert.Equal("test", parameter.ParameterName);
            Assert.Equal(DbType.Guid, parameter.DbType);
            Assert.Equal(parameterValue, parameter.Value);
        }

        [Fact]
        public void Make_NameAndNullableGuidNull_Equal()
        {
            Guid? parameterValue = null;
            var target = this.GetFactory();
            var parameter = target.Make(parameterName, parameterValue);
            Assert.Equal("test", parameter.ParameterName);
            Assert.Equal(DbType.Guid, parameter.DbType);
            Assert.Equal(DBNull.Value, parameter.Value);
        }

        #endregion

        #region Integer Tests

        [Fact]
        public void Make_NameAndIntegerNonZero_Equal()
        {
            var parameterValue = 1;
            var target = this.GetFactory();
            var parameter = target.Make(parameterName, parameterValue);
            Assert.Equal("test", parameter.ParameterName);
            Assert.Equal(DbType.Int32, parameter.DbType);
            Assert.Equal(1, parameter.Value);
        }

        [Fact]
        public void Make_NameAndIntegerZero_Equal()
        {
            var parameterValue = 0;
            var target = this.GetFactory();
            var parameter = target.Make(parameterName, parameterValue);
            Assert.Equal("test", parameter.ParameterName);
            Assert.Equal(DbType.Int32, parameter.DbType);
            Assert.Equal(0, parameter.Value);
        }

        [Fact]
        public void Make_NameAndNullableIntegerNonNull_Equal()
        {
            int? parameterValue = 1;
            var target = this.GetFactory();
            var parameter = target.Make(parameterName, parameterValue);
            Assert.Equal("test", parameter.ParameterName);
            Assert.Equal(DbType.Int32, parameter.DbType);
            Assert.Equal(1, parameter.Value);
        }

        [Fact]
        public void Make_NameAndNullableIntegerNull_Equal()
        {
            int? parameterValue = null;
            var target = this.GetFactory();
            var parameter = target.Make(parameterName, parameterValue);
            Assert.Equal("test", parameter.ParameterName);
            Assert.Equal(DbType.Int32, parameter.DbType);
            Assert.Equal(DBNull.Value, parameter.Value);
        }

        #endregion

        #region String Tests

        [Fact]
        public void Make_NameAndStringNonNull_Equal()
        {
            var parameterValue = "string";
            var target = this.GetFactory();
            var parameter = target.Make(parameterName, parameterValue);
            Assert.Equal("test", parameter.ParameterName);
            Assert.Equal(DbType.String, parameter.DbType);
            Assert.Equal("string", parameter.Value);
        }

        [Fact]
        public void Make_NameAndStringNull_Equal()
        {
            string parameterValue = null;
            var target = this.GetFactory();
            var parameter = target.Make(parameterName, parameterValue);
            Assert.Equal("test", parameter.ParameterName);
            Assert.Equal(DbType.String, parameter.DbType);
            Assert.Equal(DBNull.Value, parameter.Value);
        }

        #endregion

        private AdoParameterFactory GetFactory()
        {
            var mockParameter = new Mock<IDbDataParameter>();
            mockParameter.SetupProperty(x => x.ParameterName);
            mockParameter.SetupProperty(x => x.DbType);
            mockParameter.SetupProperty(x => x.Value);
            var mockCommand = new Mock<IDbCommand>();
            mockCommand.Setup(x => x.CreateParameter()).Returns(() => { return mockParameter.Object; });
            return new AdoParameterFactory(mockCommand.Object);
        }
    }
}
