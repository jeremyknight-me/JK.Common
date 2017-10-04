using System.Configuration;
using System.Data;
using System.Data.Common;

namespace DL.Common.Data.Ado
{
    /// <summary>
    /// Abstract base repository class which supporst ADO Database Factories.
    /// </summary>
    public abstract class AdoBaseRepository
    {
        private readonly string connectionString;

        private readonly DbProviderFactory factory;

        /// <summary>
        /// Initializes a new instance of the <see cref="AdoBaseRepository"/> class.
        /// </summary>
        /// <param name="connectionStringName">Name of the connection string to be used.</param>
        protected AdoBaseRepository(string connectionStringName)
        {
            string providerName = ConfigurationManager.ConnectionStrings[connectionStringName].ProviderName;
            this.factory = DbProviderFactories.GetFactory(providerName);
            this.connectionString = ConfigurationManager.ConnectionStrings[connectionStringName].ConnectionString;
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
                connection.ConnectionString = this.connectionString;
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
