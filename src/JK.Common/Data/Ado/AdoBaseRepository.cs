using System;
using System.Data;
using System.Data.Common;

namespace JK.Common.Data.Ado
{
    /// <summary>
    /// Abstract base repository class which supporst ADO Database Factories.
    /// </summary>
    [Obsolete("Generic ADO classes have not been tested in .NET Core. Left in for reference purposes.")]
    public abstract class AdoBaseRepository
    {
        private readonly string connString;

        private readonly DbProviderFactory factory;

        /// <summary>
        /// Initializes a new instance of the <see cref="AdoBaseRepository"/> class.
        /// </summary>
        /// <param name="providerName">Data provider to be used.</param>
        /// <param name="connectionString">Connection string to be used.</param>
        /// <remarks>
        /// The following code allows you to get the ProviderName and ConnectionString
        /// ConfigurationManager.ConnectionStrings[connectionStringName].ProviderName
        /// ConfigurationManager.ConnectionStrings[connectionStringName].ConnectionString
        /// </remarks>
        protected AdoBaseRepository(string providerName, string connectionString)
        {
            //string providerName = ;
            //this.connectionString = ;
            this.connString = connectionString;
            //this.factory = DbProviderFactories.GetFactory(providerName);
        }

        /// <summary>
        /// Uses the ADO DbProviderFactory to create a DbConnection of the correct type.
        /// </summary>
        /// <returns>DbConnection object for the provider.</returns>
        public DbConnection GetConnection()
        {
            DbConnection connection = this.factory.CreateConnection();

            if (connection != null)
            {
                connection.ConnectionString = this.connString;
            }

            return connection;
        }

        /// <summary>
        /// Creates a DbParameterFactory which uses the correct DB factory type.
        /// </summary>
        /// <returns>DbParameterFactory object.</returns>
        public AdoParameterFactory GetParameterFactory(IDbCommand command)
        {
            return new AdoParameterFactory(command);
        }
    }
}
