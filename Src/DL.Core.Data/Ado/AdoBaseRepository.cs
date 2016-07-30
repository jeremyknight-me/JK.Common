using System.Configuration;
using System.Data.Common;

namespace DL.Core.Data.Ado
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
        /// Gets a DbConnection of the correct type from the ADO DbProviderFactory.
        /// </summary>
        public DbConnection Connection
        {
            get
            {
                DbConnection connection = this.factory.CreateConnection();

                if (connection != null)
                {
                    connection.ConnectionString = this.connectionString;
                }

                return connection;
            }
        }

        /// <summary>
        /// Gets a DbParameterFactory which uses the correct DB factory type.
        /// </summary>
        public DbParameterFactory ParameterFactory
        {
            get { return new DbParameterFactory(this.factory); }
        }
    }
}
