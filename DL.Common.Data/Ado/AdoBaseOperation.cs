using System.Data;
using System.Data.Common;

namespace DL.Common.Data.Ado
{
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

        protected AdoBaseRepository Repository => this.repository;

        protected abstract void SetupParameters(DbCommand command);

        protected AdoParameterFactory GetParameterFactory(IDbCommand command)
        {
            return this.repository.GetParameterFactory(command);
        }

        protected DbCommand SetupCommand(DbConnection connection, CommandType commandType, string commandText)
        {
            DbCommand command = connection.CreateCommand();
            command.CommandType = commandType;
            command.CommandText = commandText;
            this.SetupParameters(command);
            return command;
        }
    }
}
