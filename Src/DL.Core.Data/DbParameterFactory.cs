using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;

namespace DL.Core.Data
{
    /// <summary>
    /// Class which created and sets up DbParameters for ADO use.
    /// </summary>
    public class DbParameterFactory
    {
        private readonly Dictionary<Type, DbType> strategies = new Dictionary<Type, DbType>();

        private readonly DbProviderFactory factory;

        /// <summary>
        /// Initializes a new instance of the DbParameterFactory class.
        /// </summary>
        /// <param name="providerFactory">The ADO DB Provider Factory.</param>
        public DbParameterFactory(DbProviderFactory providerFactory)
        {
            this.factory = providerFactory;
            this.DefineStrategies();
        }

        #region Public Methods

        /// <summary>
        /// Uses the ADO DbProviderFactory to create a DbParameter of the correct type.
        /// </summary>
        /// <param name="name">Name of parameter.</param>
        /// <param name="databaseType">Database type of parameter.</param>
        /// <returns>DbParameter object for the provider.</returns>
        public DbParameter Make(string name, DbType databaseType)
        {
            DbParameter parameter = this.factory.CreateParameter();

            if (parameter == null)
            {
                return null;
            }

            parameter.DbType = databaseType;
            parameter.ParameterName = name;
            return parameter;
        }

        /// <summary>
        /// Uses the ADO DbProviderFactory to create a DbParameter of the correct type.
        /// </summary>
        /// <typeparam name="T">Generic type to use.</typeparam>
        /// <param name="name">Name of parameter.</param>
        /// <param name="value">Value to insert into parameter.</param>
        /// <returns>DbParameter object for the provider.</returns>
        public DbParameter Make<T>(string name, T value)
        {
            DbType databaseType = this.strategies[typeof(T)];
            DbParameter parameter = this.Make(name, databaseType);
            parameter.Value = value;
            return parameter;
        }

        /// <summary>
        /// Uses the ADO DbProviderFactory to create a DbParameter of the correct type.
        /// </summary>
        /// <typeparam name="T">Generic type to use.</typeparam>
        /// <param name="name">Name of parameter.</param>
        /// <param name="value">Value to insert into parameter.</param>
        /// <returns>DbParameter object for the provider.</returns>
        public DbParameter Make<T>(string name, T? value) where T : struct
        {
            DbType databaseType = this.strategies[typeof(T)];
            DbParameter parameter = this.Make(name, databaseType);
            parameter.Value = this.LoadValue(value);
            return parameter;
        }

        /// <summary>
        /// Uses the ADO DbProviderFactory to create a String DbParameter.
        /// </summary>
        /// <param name="name">Name of parameter.</param>
        /// <param name="value">String value to insert into parameter.</param>
        /// <returns>DbParameter object for the provider.</returns>
        public DbParameter Make(string name, string value)
        {
            DbParameter parameter = this.Make(name, DbType.String);
            parameter.Value = this.LoadValue(value);
            return parameter;
        }

        #endregion

        private void DefineStrategies()
        {
            this.strategies.Add(typeof(bool), DbType.Boolean);
            this.strategies.Add(typeof(DateTime), DbType.DateTime);
            this.strategies.Add(typeof(DateTimeOffset), DbType.DateTimeOffset);
            this.strategies.Add(typeof(decimal), DbType.Decimal);
            this.strategies.Add(typeof(double), DbType.Double);
            this.strategies.Add(typeof(Guid), DbType.Guid);
            this.strategies.Add(typeof(int), DbType.Int32);
            this.strategies.Add(typeof(string), DbType.String);
        }

        private object LoadValue(string value)
        {
            if (!string.IsNullOrEmpty(value))
            {
                return value;
            }

            return DBNull.Value;
        }

        private object LoadValue<T>(T? value) where T : struct
        {
            return value.HasValue ? (object)value.Value : DBNull.Value;
        }
    }
}
