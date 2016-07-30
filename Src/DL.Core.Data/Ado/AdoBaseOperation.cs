using System;
using System.Data;
using System.Data.Common;

namespace DL.Core.Data.Ado
{
    /// <summary>
    /// Abstract base operation class which supports ADO Database command operations.
    /// </summary>
    public abstract class AdoBaseOperation
    {
        private readonly AdoBaseRepository repository;

        /// <summary>
        /// Initializes a new instance of the AdoBaseOperation class.
        /// </summary>
        /// <param name="adoBaseRepository">The ADO base repository to use.</param>
        protected AdoBaseOperation(AdoBaseRepository adoBaseRepository)
        {
            this.repository = adoBaseRepository;
        }

        /// <summary>
        /// Gets the repository for the operation.
        /// </summary>
        protected AdoBaseRepository Repository
        {
            get { return this.repository; }
        }

        /// <summary>
        /// Gets the parameter factory for the operation.
        /// </summary>
        protected DbParameterFactory ParameterFactory
        {
            get { return this.repository.ParameterFactory; }
        }

        /// <summary>
        /// Abstract method used to setup parameters for an ADO operation.
        /// </summary>
        /// <param name="command">DbCommand in which to add parameters.</param>
        protected abstract void SetupParameters(DbCommand command);

        protected DbCommand SetupCommand(DbConnection connection, CommandType commandType, string commandText)
        {
            if (connection == null)
            {
                throw new ArgumentNullException("connection");
            }

            DbCommand command = connection.CreateCommand();
            command.CommandType = commandType;
            command.CommandText = commandText;
            this.SetupParameters(command);
            return command;
        }
    }
}
