using System;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using DL.Common.Data.SqlClient;
using Xunit;

namespace DL.Common.Tests.Data
{
    public class SqlParameterFactoryTests
    {
        private const string parameterName = "test";

        [Fact]
        public void Make_NameAndType_Equal()
        {
            var databaseType = SqlDbType.NVarChar;
            var target = this.GetFactory();
            var parameter = target.Make(parameterName, databaseType) as SqlParameter;
            Assert.Equal("test", parameter.ParameterName);
            Assert.Equal(DbType.String, parameter.DbType);
            Assert.Equal(SqlDbType.NVarChar, parameter.SqlDbType);
        }

        #region Boolean Tests

        [Fact]
        public void Make_NameAndBooleanTrue_Equal()
        {
            bool parameterValue = true;
            var target = this.GetFactory();
            var parameter = target.Make(parameterName, parameterValue) as SqlParameter;
            Assert.Equal("test", parameter.ParameterName);
            Assert.Equal(DbType.Boolean, parameter.DbType);
            Assert.Equal(SqlDbType.Bit, parameter.SqlDbType);
            Assert.Equal(true, parameter.Value);
        }

        [Fact]
        public void Make_NameAndBooleanFalse_Equal()
        {
            bool parameterValue = false;
            var target = this.GetFactory();
            var parameter = target.Make(parameterName, parameterValue) as SqlParameter;
            Assert.Equal("test", parameter.ParameterName);
            Assert.Equal(DbType.Boolean, parameter.DbType);
            Assert.Equal(SqlDbType.Bit, parameter.SqlDbType);
            Assert.Equal(false, parameter.Value);
        }

        [Fact]
        public void Make_NameAndNullableBooleanNonNull_Equal()
        {
            bool? parameterValue = true;
            var target = this.GetFactory();
            var parameter = target.Make(parameterName, parameterValue) as SqlParameter;
            Assert.Equal("test", parameter.ParameterName);
            Assert.Equal(DbType.Boolean, parameter.DbType);
            Assert.Equal(SqlDbType.Bit, parameter.SqlDbType);
            Assert.Equal(true, parameter.Value);
        }

        [Fact]
        public void Make_NameAndNullableBooleanNull_Equal()
        {
            bool? parameterValue = null;
            var target = this.GetFactory();
            var parameter = target.Make(parameterName, parameterValue) as SqlParameter;
            Assert.Equal("test", parameter.ParameterName);
            Assert.Equal(DbType.Boolean, parameter.DbType);
            Assert.Equal(SqlDbType.Bit, parameter.SqlDbType);
            Assert.Equal(DBNull.Value, parameter.Value);
        }

        #endregion

        #region DateTime Tests

        [Fact]
        public void Make_NameAndDateTimeNotNull_Equal()
        {
            DateTime parameterValue = DateTime.Now;
            var target = this.GetFactory();
            var parameter = target.Make(parameterName, parameterValue) as SqlParameter;
            Assert.Equal("test", parameter.ParameterName);
            Assert.Equal(DbType.DateTime, parameter.DbType);
            Assert.Equal(SqlDbType.DateTime, parameter.SqlDbType);
            Assert.Equal(parameterValue, parameter.Value);
        }

        [Fact]
        public void Make_NameAndNullableDateTimeNotNull_Equal()
        {
            DateTime? parameterValue = DateTime.Now;
            var target = this.GetFactory();
            var parameter = target.Make(parameterName, parameterValue) as SqlParameter;
            Assert.Equal("test", parameter.ParameterName);
            Assert.Equal(DbType.DateTime, parameter.DbType);
            Assert.Equal(SqlDbType.DateTime, parameter.SqlDbType);
            Assert.Equal(parameterValue, parameter.Value);
        }

        [Fact]
        public void Make_NameAndNullableDateTimeNull_Equal()
        {
            DateTime? parameterValue = null;
            var target = this.GetFactory();
            var parameter = target.Make(parameterName, parameterValue) as SqlParameter;
            Assert.Equal("test", parameter.ParameterName);
            Assert.Equal(DbType.DateTime, parameter.DbType);
            Assert.Equal(SqlDbType.DateTime, parameter.SqlDbType);
            Assert.Equal(DBNull.Value, parameter.Value);
        }

        #endregion

        #region DateTimeOffset Tests

        [Fact]
        public void Make_NameAndDateTimeOffsetNotNull_Equal()
        {
            DateTimeOffset parameterValue = DateTimeOffset.Now;
            var target = this.GetFactory();
            var parameter = target.Make(parameterName, parameterValue) as SqlParameter;
            Assert.Equal("test", parameter.ParameterName);
            Assert.Equal(DbType.DateTimeOffset, parameter.DbType);
            Assert.Equal(SqlDbType.DateTimeOffset, parameter.SqlDbType);
            Assert.Equal(parameterValue, parameter.Value);
        }

        [Fact]
        public void Make_NameAndNullableDateTimeOffsetNotNull_Equal()
        {
            DateTimeOffset? parameterValue = DateTimeOffset.Now;
            var target = this.GetFactory();
            var parameter = target.Make(parameterName, parameterValue) as SqlParameter;
            Assert.Equal("test", parameter.ParameterName);
            Assert.Equal(DbType.DateTimeOffset, parameter.DbType);
            Assert.Equal(SqlDbType.DateTimeOffset, parameter.SqlDbType);
            Assert.Equal(parameterValue, parameter.Value);
        }

        [Fact]
        public void Make_NameAndNullableDateTimeOffsetNull_Equal()
        {
            DateTimeOffset? parameterValue = null;
            var target = this.GetFactory();
            var parameter = target.Make(parameterName, parameterValue) as SqlParameter;
            Assert.Equal("test", parameter.ParameterName);
            Assert.Equal(DbType.DateTimeOffset, parameter.DbType);
            Assert.Equal(SqlDbType.DateTimeOffset, parameter.SqlDbType);
            Assert.Equal(DBNull.Value, parameter.Value);
        }

        #endregion

        #region Decimal Tests

        [Fact]
        public void Make_NameAndDecimalNonZero_Equal()
        {
            decimal parameterValue = 1;
            var target = this.GetFactory();
            var parameter = target.Make(parameterName, parameterValue) as SqlParameter;
            Assert.Equal("test", parameter.ParameterName);
            Assert.Equal(DbType.Decimal, parameter.DbType);
            Assert.Equal(SqlDbType.Decimal, parameter.SqlDbType);
            Assert.Equal(1m, parameter.Value);
        }

        [Fact]
        public void Make_NameAndDecimalZero_Equal()
        {
            decimal parameterValue = 0;
            var target = this.GetFactory();
            var parameter = target.Make(parameterName, parameterValue) as SqlParameter;
            Assert.Equal("test", parameter.ParameterName);
            Assert.Equal(DbType.Decimal, parameter.DbType);
            Assert.Equal(SqlDbType.Decimal, parameter.SqlDbType);
            Assert.Equal(0m, parameter.Value);
        }

        [Fact]
        public void Make_NameAndNullableDecimalNonNull_Equal()
        {
            decimal? parameterValue = 1;
            var target = this.GetFactory();
            var parameter = target.Make(parameterName, parameterValue) as SqlParameter;
            Assert.Equal("test", parameter.ParameterName);
            Assert.Equal(DbType.Decimal, parameter.DbType);
            Assert.Equal(SqlDbType.Decimal, parameter.SqlDbType);
            Assert.Equal(1m, parameter.Value);
        }

        [Fact]
        public void Make_NameAndNullableDecimalNull_Equal()
        {
            decimal? parameterValue = null;
            var target = this.GetFactory();
            var parameter = target.Make(parameterName, parameterValue) as SqlParameter;
            Assert.Equal("test", parameter.ParameterName);
            Assert.Equal(DbType.Decimal, parameter.DbType);
            Assert.Equal(SqlDbType.Decimal, parameter.SqlDbType);
            Assert.Equal(DBNull.Value, parameter.Value);
        }

        #endregion

        #region Double Tests

        [Fact]
        public void Make_NameAndDoubleNonZero_Equal()
        {
            double parameterValue = 1;
            var target = this.GetFactory();
            var parameter = target.Make(parameterName, parameterValue) as SqlParameter;
            Assert.Equal("test", parameter.ParameterName);
            Assert.Equal(DbType.Double, parameter.DbType);
            Assert.Equal(SqlDbType.Float, parameter.SqlDbType);
            Assert.Equal(1D, parameter.Value);
        }

        [Fact]
        public void Make_NameAndDoubleZero_Equal()
        {
            double parameterValue = 0;
            var target = this.GetFactory();
            var parameter = target.Make(parameterName, parameterValue) as SqlParameter;
            Assert.Equal("test", parameter.ParameterName);
            Assert.Equal(DbType.Double, parameter.DbType);
            Assert.Equal(SqlDbType.Float, parameter.SqlDbType);
            Assert.Equal(0D, parameter.Value);
        }

        [Fact]
        public void Make_NameAndNullableDoubleNonNull_Equal()
        {
            double? parameterValue = 1;
            var target = this.GetFactory();
            var parameter = target.Make(parameterName, parameterValue) as SqlParameter;
            Assert.Equal("test", parameter.ParameterName);
            Assert.Equal(DbType.Double, parameter.DbType);
            Assert.Equal(SqlDbType.Float, parameter.SqlDbType);
            Assert.Equal(1D, parameter.Value);
        }

        [Fact]
        public void Make_NameAndNullableDoubleNull_Equal()
        {
            double? parameterValue = null;
            var target = this.GetFactory();
            var parameter = target.Make(parameterName, parameterValue) as SqlParameter;
            Assert.Equal("test", parameter.ParameterName);
            Assert.Equal(DbType.Double, parameter.DbType);
            Assert.Equal(SqlDbType.Float, parameter.SqlDbType);
            Assert.Equal(DBNull.Value, parameter.Value);
        }

        #endregion

        #region Guid Tests

        [Fact]
        public void Make_NameAndGuidNotNull_Equal()
        {
            var parameterValue = Guid.NewGuid();
            var target = this.GetFactory();
            var parameter = target.Make(parameterName, parameterValue) as SqlParameter;
            Assert.Equal("test", parameter.ParameterName);
            Assert.Equal(DbType.Guid, parameter.DbType);
            Assert.Equal(SqlDbType.UniqueIdentifier, parameter.SqlDbType);
            Assert.Equal(parameterValue, parameter.Value);
        }

        [Fact]
        public void Make_NameAndNullableGuidNotNull_Equal()
        {
            Guid? parameterValue = Guid.NewGuid();
            var target = this.GetFactory();
            var parameter = target.Make(parameterName, parameterValue) as SqlParameter;
            Assert.Equal("test", parameter.ParameterName);
            Assert.Equal(DbType.Guid, parameter.DbType);
            Assert.Equal(SqlDbType.UniqueIdentifier, parameter.SqlDbType);
            Assert.Equal(parameterValue, parameter.Value);
        }

        [Fact]
        public void Make_NameAndNullableGuidNull_Equal()
        {
            Guid? parameterValue = null;
            var target = this.GetFactory();
            var parameter = target.Make(parameterName, parameterValue) as SqlParameter;
            Assert.Equal("test", parameter.ParameterName);
            Assert.Equal(DbType.Guid, parameter.DbType);
            Assert.Equal(SqlDbType.UniqueIdentifier, parameter.SqlDbType);
            Assert.Equal(DBNull.Value, parameter.Value);
        }

        #endregion

        #region Integer Tests

        [Fact]
        public void Make_NameAndIntegerNonZero_Equal()
        {
            int parameterValue = 1;
            var target = this.GetFactory();
            var parameter = target.Make(parameterName, parameterValue) as SqlParameter;
            Assert.Equal("test", parameter.ParameterName);
            Assert.Equal(DbType.Int32, parameter.DbType);
            Assert.Equal(SqlDbType.Int, parameter.SqlDbType);
            Assert.Equal(1, parameter.Value);
        }

        [Fact]
        public void Make_NameAndIntegerZero_Equal()
        {
            int parameterValue = 0;
            var target = this.GetFactory();
            var parameter = target.Make(parameterName, parameterValue) as SqlParameter;
            Assert.Equal("test", parameter.ParameterName);
            Assert.Equal(DbType.Int32, parameter.DbType);
            Assert.Equal(SqlDbType.Int, parameter.SqlDbType);
            Assert.Equal(0, parameter.Value);
        }

        [Fact]
        public void Make_NameAndNullableIntegerNonNull_Equal()
        {
            int? parameterValue = 1;
            var target = this.GetFactory();
            var parameter = target.Make(parameterName, parameterValue) as SqlParameter;
            Assert.Equal("test", parameter.ParameterName);
            Assert.Equal(DbType.Int32, parameter.DbType);
            Assert.Equal(SqlDbType.Int, parameter.SqlDbType);
            Assert.Equal(1, parameter.Value);
        }

        [Fact]
        public void Make_NameAndNullableIntegerNull_Equal()
        {
            int? parameterValue = null;
            var target = this.GetFactory();
            var parameter = target.Make(parameterName, parameterValue) as SqlParameter;
            Assert.Equal("test", parameter.ParameterName);
            Assert.Equal(DbType.Int32, parameter.DbType);
            Assert.Equal(SqlDbType.Int, parameter.SqlDbType);
            Assert.Equal(DBNull.Value, parameter.Value);
        }

        #endregion

        #region String Tests

        [Fact]
        public void Make_NameAndStringNonNull_Equal()
        {
            string parameterValue = "string";
            var target = this.GetFactory();
            var parameter = target.Make(parameterName, parameterValue) as SqlParameter;
            Assert.Equal("test", parameter.ParameterName);
            Assert.Equal(DbType.String, parameter.DbType);
            Assert.Equal(SqlDbType.NVarChar, parameter.SqlDbType);
            Assert.Equal("string", parameter.Value);
        }

        [Fact]
        public void Make_NameAndStringNull_Equal()
        {
            string parameterValue = null;
            var target = this.GetFactory();
            var parameter = target.Make(parameterName, parameterValue) as SqlParameter;
            Assert.Equal("test", parameter.ParameterName);
            Assert.Equal(DbType.String, parameter.DbType);
            Assert.Equal(SqlDbType.NVarChar, parameter.SqlDbType);
            Assert.Equal(DBNull.Value, parameter.Value);
        }

        #endregion

        private SqlParameterFactory GetFactory()
        {
            var factory = DbProviderFactories.GetFactory("System.Data.SqlClient");
            return new SqlParameterFactory(factory.CreateCommand());
        }
    }
}
