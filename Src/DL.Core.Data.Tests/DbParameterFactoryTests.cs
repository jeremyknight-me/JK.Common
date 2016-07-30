using System;
using System.Data;
using System.Data.Common;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DL.Core.Data.Tests
{
    [TestClass]
    public class DbParameterFactoryTests
    {
        private DbParameterFactory testObject;

        private string parameterName;

        [TestInitialize]
        public void TestInitialize()
        {
            DbProviderFactory factory = DbProviderFactories.GetFactory("System.Data.SqlClient");
            this.testObject = new DbParameterFactory(factory);
            this.parameterName = "test";
        }

        [TestCleanup]
        public void TestCleanup()
        {
            this.testObject = null;
        }

        [TestMethod]
        public void Make_NameAndType_Equal()
        {
            // arrange
            DbType databaseType = DbType.String;

            // act
            DbParameter parameter = this.testObject.Make(this.parameterName, databaseType);

            // assert
            Assert.AreEqual("test", parameter.ParameterName);
            Assert.AreEqual(DbType.String, parameter.DbType);
        }

        // Guid

        #region Boolean Tests

        [TestMethod]
        public void Make_NameAndBooleanTrue_Equal()
        {
            // arrange
            bool parameterValue = true;

            // act
            DbParameter parameter = this.testObject.Make(this.parameterName, parameterValue);

            // assert
            Assert.AreEqual("test", parameter.ParameterName);
            Assert.AreEqual(DbType.Boolean, parameter.DbType);
            Assert.AreEqual(true, parameter.Value);
        }

        [TestMethod]
        public void Make_NameAndBooleanFalse_Equal()
        {
            // arrange
            bool parameterValue = false;

            // act
            DbParameter parameter = this.testObject.Make(this.parameterName, parameterValue);

            // assert
            Assert.AreEqual("test", parameter.ParameterName);
            Assert.AreEqual(DbType.Boolean, parameter.DbType);
            Assert.AreEqual(false, parameter.Value);
        }

        [TestMethod]
        public void Make_NameAndNullableBooleanNonNull_Equal()
        {
            // arrange
            bool? parameterValue = true;

            // act
            DbParameter parameter = this.testObject.Make(this.parameterName, parameterValue);

            // assert
            Assert.AreEqual("test", parameter.ParameterName);
            Assert.AreEqual(DbType.Boolean, parameter.DbType);
            Assert.AreEqual(true, parameter.Value);
        }

        [TestMethod]
        public void Make_NameAndNullableBooleanNull_Equal()
        {
            // arrange
            bool? parameterValue = null;

            // act
            DbParameter parameter = this.testObject.Make(this.parameterName, parameterValue);

            // assert
            Assert.AreEqual("test", parameter.ParameterName);
            Assert.AreEqual(DbType.Boolean, parameter.DbType);
            Assert.AreEqual(DBNull.Value, parameter.Value);
        }

        #endregion

        #region DateTime Tests

        [TestMethod]
        public void Make_NameAndDateTimeNotNull_Equal()
        {
            // arrange
            DateTime parameterValue = DateTime.Now;

            // act
            DbParameter parameter = this.testObject.Make(this.parameterName, parameterValue);

            // assert
            Assert.AreEqual("test", parameter.ParameterName);
            Assert.AreEqual(DbType.DateTime, parameter.DbType);
            Assert.AreEqual(parameterValue, parameter.Value);
        }

        [TestMethod]
        public void Make_NameAndNullableDateTimeNotNull_Equal()
        {
            // arrange
            DateTime? parameterValue = DateTime.Now;

            // act
            DbParameter parameter = this.testObject.Make(this.parameterName, parameterValue);

            // assert
            Assert.AreEqual("test", parameter.ParameterName);
            Assert.AreEqual(DbType.DateTime, parameter.DbType);
            Assert.AreEqual(parameterValue, parameter.Value);
        }

        [TestMethod]
        public void Make_NameAndNullableDateTimeNull_Equal()
        {
            // arrange
            DateTime? parameterValue = null;

            // act
            DbParameter parameter = this.testObject.Make(this.parameterName, parameterValue);

            // assert
            Assert.AreEqual("test", parameter.ParameterName);
            Assert.AreEqual(DbType.DateTime, parameter.DbType);
            Assert.AreEqual(DBNull.Value, parameter.Value);
        }

        #endregion

        #region DateTimeOffset Tests

        [TestMethod]
        public void Make_NameAndDateTimeOffsetNotNull_Equal()
        {
            // arrange
            DateTimeOffset parameterValue = DateTimeOffset.Now;

            // act
            DbParameter parameter = this.testObject.Make(this.parameterName, parameterValue);

            // assert
            Assert.AreEqual("test", parameter.ParameterName);
            Assert.AreEqual(DbType.DateTimeOffset, parameter.DbType);
            Assert.AreEqual(parameterValue, parameter.Value);
        }

        [TestMethod]
        public void Make_NameAndNullableDateTimeOffsetNotNull_Equal()
        {
            // arrange
            DateTimeOffset? parameterValue = DateTimeOffset.Now;

            // act
            DbParameter parameter = this.testObject.Make(this.parameterName, parameterValue);

            // assert
            Assert.AreEqual("test", parameter.ParameterName);
            Assert.AreEqual(DbType.DateTimeOffset, parameter.DbType);
            Assert.AreEqual(parameterValue, parameter.Value);
        }

        [TestMethod]
        public void Make_NameAndNullableDateTimeOffsetNull_Equal()
        {
            // arrange
            DateTimeOffset? parameterValue = null;

            // act
            DbParameter parameter = this.testObject.Make(this.parameterName, parameterValue);

            // assert
            Assert.AreEqual("test", parameter.ParameterName);
            Assert.AreEqual(DbType.DateTimeOffset, parameter.DbType);
            Assert.AreEqual(DBNull.Value, parameter.Value);
        }

        #endregion

        #region Decimal Tests

        [TestMethod]
        public void Make_NameAndDecimalNonZero_Equal()
        {
            // arrange
            decimal parameterValue = 1;

            // act
            DbParameter parameter = this.testObject.Make(this.parameterName, parameterValue);

            // assert
            Assert.AreEqual("test", parameter.ParameterName);
            Assert.AreEqual(DbType.Decimal, parameter.DbType);
            Assert.AreEqual(1m, parameter.Value);
        }

        [TestMethod]
        public void Make_NameAndDecimalZero_Equal()
        {
            // arrange
            decimal parameterValue = 0;

            // act
            DbParameter parameter = this.testObject.Make(this.parameterName, parameterValue);

            // assert
            Assert.AreEqual("test", parameter.ParameterName);
            Assert.AreEqual(DbType.Decimal, parameter.DbType);
            Assert.AreEqual(0m, parameter.Value);
        }

        [TestMethod]
        public void Make_NameAndNullableDecimalNonNull_Equal()
        {
            // arrange
            decimal? parameterValue = 1;

            // act
            DbParameter parameter = this.testObject.Make(this.parameterName, parameterValue);

            // assert
            Assert.AreEqual("test", parameter.ParameterName);
            Assert.AreEqual(DbType.Decimal, parameter.DbType);
            Assert.AreEqual(1m, parameter.Value);
        }

        [TestMethod]
        public void Make_NameAndNullableDecimalNull_Equal()
        {
            // arrange
            decimal? parameterValue = null;

            // act
            DbParameter parameter = this.testObject.Make(this.parameterName, parameterValue);

            // assert
            Assert.AreEqual("test", parameter.ParameterName);
            Assert.AreEqual(DbType.Decimal, parameter.DbType);
            Assert.AreEqual(DBNull.Value, parameter.Value);
        }

        #endregion

        #region Double Tests

        [TestMethod]
        public void Make_NameAndDoubleNonZero_Equal()
        {
            // arrange
            double parameterValue = 1;

            // act
            DbParameter parameter = this.testObject.Make(this.parameterName, parameterValue);

            // assert
            Assert.AreEqual("test", parameter.ParameterName);
            Assert.AreEqual(DbType.Double, parameter.DbType);
            Assert.AreEqual(1D, parameter.Value);
        }

        [TestMethod]
        public void Make_NameAndDoubleZero_Equal()
        {
            // arrange
            double parameterValue = 0;

            // act
            DbParameter parameter = this.testObject.Make(this.parameterName, parameterValue);

            // assert
            Assert.AreEqual("test", parameter.ParameterName);
            Assert.AreEqual(DbType.Double, parameter.DbType);
            Assert.AreEqual(0D, parameter.Value);
        }

        [TestMethod]
        public void Make_NameAndNullableDoubleNonNull_Equal()
        {
            // arrange
            double? parameterValue = 1;

            // act
            DbParameter parameter = this.testObject.Make(this.parameterName, parameterValue);

            // assert
            Assert.AreEqual("test", parameter.ParameterName);
            Assert.AreEqual(DbType.Double, parameter.DbType);
            Assert.AreEqual(1D, parameter.Value);
        }

        [TestMethod]
        public void Make_NameAndNullableDoubleNull_Equal()
        {
            // arrange
            double? parameterValue = null;

            // act
            DbParameter parameter = this.testObject.Make(this.parameterName, parameterValue);

            // assert
            Assert.AreEqual("test", parameter.ParameterName);
            Assert.AreEqual(DbType.Double, parameter.DbType);
            Assert.AreEqual(DBNull.Value, parameter.Value);
        }

        #endregion

        #region Guid Tests

        [TestMethod]
        public void Make_NameAndGuidNotNull_Equal()
        {
            // arrange
            Guid parameterValue = Guid.NewGuid();

            // act
            DbParameter parameter = this.testObject.Make(this.parameterName, parameterValue);

            // assert
            Assert.AreEqual("test", parameter.ParameterName);
            Assert.AreEqual(DbType.Guid, parameter.DbType);
            Assert.AreEqual(parameterValue, parameter.Value);
        }

        [TestMethod]
        public void Make_NameAndNullableGuidNotNull_Equal()
        {
            // arrange
            Guid? parameterValue = Guid.NewGuid();

            // act
            DbParameter parameter = this.testObject.Make(this.parameterName, parameterValue);

            // assert
            Assert.AreEqual("test", parameter.ParameterName);
            Assert.AreEqual(DbType.Guid, parameter.DbType);
            Assert.AreEqual(parameterValue, parameter.Value);
        }

        [TestMethod]
        public void Make_NameAndNullableGuidNull_Equal()
        {
            // arrange
            Guid? parameterValue = null;

            // act
            DbParameter parameter = this.testObject.Make(this.parameterName, parameterValue);

            // assert
            Assert.AreEqual("test", parameter.ParameterName);
            Assert.AreEqual(DbType.Guid, parameter.DbType);
            Assert.AreEqual(DBNull.Value, parameter.Value);
        }

        #endregion

        #region Integer Tests

        [TestMethod]
        public void Make_NameAndIntegerNonZero_Equal()
        {
            // arrange
            int parameterValue = 1;

            // act
            DbParameter parameter = this.testObject.Make(this.parameterName, parameterValue);

            // assert
            Assert.AreEqual("test", parameter.ParameterName);
            Assert.AreEqual(DbType.Int32, parameter.DbType);
            Assert.AreEqual(1, parameter.Value);
        }

        [TestMethod]
        public void Make_NameAndIntegerZero_Equal()
        {
            // arrange
            int parameterValue = 0;

            // act
            DbParameter parameter = this.testObject.Make(this.parameterName, parameterValue);

            // assert
            Assert.AreEqual("test", parameter.ParameterName);
            Assert.AreEqual(DbType.Int32, parameter.DbType);
            Assert.AreEqual(0, parameter.Value);
        }

        [TestMethod]
        public void Make_NameAndNullableIntegerNonNull_Equal()
        {
            // arrange
            int? parameterValue = 1;

            // act
            DbParameter parameter = this.testObject.Make(this.parameterName, parameterValue);

            // assert
            Assert.AreEqual("test", parameter.ParameterName);
            Assert.AreEqual(DbType.Int32, parameter.DbType);
            Assert.AreEqual(1, parameter.Value);
        }

        [TestMethod]
        public void Make_NameAndNullableIntegerNull_Equal()
        {
            // arrange
            int? parameterValue = null;

            // act
            DbParameter parameter = this.testObject.Make(this.parameterName, parameterValue);

            // assert
            Assert.AreEqual("test", parameter.ParameterName);
            Assert.AreEqual(DbType.Int32, parameter.DbType);
            Assert.AreEqual(DBNull.Value, parameter.Value);
        }

        #endregion

        #region String Tests

        [TestMethod]
        public void Make_NameAndStringNonNull_Equal()
        {
            // arrange
            string parameterValue = "string";

            // act
            DbParameter parameter = this.testObject.Make(this.parameterName, parameterValue);

            // assert
            Assert.AreEqual("test", parameter.ParameterName);
            Assert.AreEqual(DbType.String, parameter.DbType);
            Assert.AreEqual("string", parameter.Value);
        }

        [TestMethod]
        public void Make_NameAndStringNull_Equal()
        {
            // arrange
            string parameterValue = null;

            // act
            DbParameter parameter = this.testObject.Make(this.parameterName, parameterValue);

            // assert
            Assert.AreEqual("test", parameter.ParameterName);
            Assert.AreEqual(DbType.String, parameter.DbType);
            Assert.AreEqual(DBNull.Value, parameter.Value);
        }

        #endregion
    }
}
