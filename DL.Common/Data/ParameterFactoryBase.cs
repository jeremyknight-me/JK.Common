using System;
using System.Collections.Generic;
using System.Data;

namespace DL.Common.Data
{
    public abstract class ParameterFactoryBase<TDbType> where TDbType : struct, IConvertible
    {
        private readonly IDbCommand command;
        private Dictionary<Type, TDbType> strategies;

        protected ParameterFactoryBase(IDbCommand commandToUse)
        {
            this.command = commandToUse;
        }

        protected Dictionary<Type, TDbType> Strategies
        {
            get
            {
                if (this.strategies == null)
                {
                    this.strategies = new Dictionary<Type, TDbType>();
                    this.DefineStrategies();
                }
                
                return this.strategies;
            }
        }

        public abstract IDbDataParameter Make(string name, TDbType databaseType);

        /// <summary>
        /// Uses the ADO DbProviderFactory to create a DbParameter of the correct type.
        /// </summary>
        /// <typeparam name="T">Generic type to use.</typeparam>
        /// <param name="name">Name of parameter.</param>
        /// <param name="value">Value to insert into parameter.</param>
        /// <returns>DbParameter object for the provider.</returns>
        public IDbDataParameter Make<T>(string name, T value)
        {
            TDbType databaseType = this.Strategies[typeof(T)];
            var parameter = this.Make(name, databaseType);
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
        public IDbDataParameter Make<T>(string name, T? value) where T : struct
        {
            TDbType databaseType = this.Strategies[typeof(T)];
            var parameter = this.Make(name, databaseType);
            parameter.Value = this.LoadValue(value);
            return parameter;
        }

        /// <summary>
        /// Uses the ADO DbProviderFactory to create a String DbParameter.
        /// </summary>
        /// <param name="name">Name of parameter.</param>
        /// <param name="value">String value to insert into parameter.</param>
        /// <returns>DbParameter object for the provider.</returns>
        public IDbDataParameter Make(string name, string value)
        {
            var parameter = this.Make(name);
            parameter.DbType = DbType.String;
            parameter.Value = this.LoadValue(value);
            return parameter;
        }

        protected abstract void DefineStrategies();

        protected IDbDataParameter Make(string name)
        {
            var parameter = this.command.CreateParameter();
            parameter.ParameterName = name;
            return parameter;
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
