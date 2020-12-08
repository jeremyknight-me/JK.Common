using System;
using System.Data;

namespace JK.Common.Data.Ado
{
    /// <summary>
    /// Abstract base data context class 
    /// </summary>
    public abstract class DataContextBase : IDisposable
    {
        private IDbConnection connection;

        /// <summary>
        /// Initializes a new instance of the <see cref="DataContextBase"/> class.
        /// </summary>
        /// <param name="connectionString">Connection string to be used.</param>
        protected DataContextBase(string connectionString)
        {
            this.ConnectionString = connectionString;
        }

        public string ConnectionString { get;  }

        public IDbConnection Connection
        {
            get
            {
                if (this.connection is null)
                {
                    this.connection = this.MakeConnection();
                }

                return this.connection;
            }
        }

        public void Dispose()
        {
            if (this.connection != null)
            {
                this.connection.Dispose();
            }
        }

        public void OpenConnection()
        {
            if (this.Connection.State != ConnectionState.Open)
            {
                this.Connection.Open();
            }
        }

        public void CloseConnection()
        {
            if (this.Connection.State != ConnectionState.Closed)
            {
                this.Connection.Close();
            }
        }

        public abstract IParameterFactory MakeParameterFactory(IDbCommand command);
        protected abstract IDbConnection MakeConnection();
    }
}
