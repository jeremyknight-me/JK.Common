using System.Data;
using System.Data.Common;
using System.Transactions;

namespace DL.Core.Data.Ado
{
    /// <summary>
    /// Abstract base operation class which supports ADO Database non-query command operations.
    /// </summary>
    public abstract class AdoNonQueryOperation : AdoBaseOperation, INonQueryOperation
    {
        private readonly CommandType commandType;

        private readonly string commandText;

        /// <summary>
        /// Initializes a new instance of the <see cref="AdoNonQueryOperation"/> class.
        /// </summary>
        /// <param name="repository">Repository object used by the operation.</param>
        /// <param name="adoCommandType">Command type of the operation: stored procedure or text.</param>
        /// <param name="adoCommandText">
        /// Command text of the operation. The stored procedure name if type is stored procedure.
        /// The parameterized SQL statement if type is text.
        /// </param>
        protected AdoNonQueryOperation(AdoBaseRepository repository, CommandType adoCommandType, string adoCommandText)
            : base(repository)
        {
            this.commandType = adoCommandType;
            this.commandText = adoCommandText;
        }

        public void Execute()
        {
            using (var scope = new TransactionScope())
            {
                using (DbConnection connection = this.Repository.Connection)
                using (DbCommand command = this.SetupCommand(connection, this.commandType, this.commandText))
                {
                    command.Connection.Open();
                    command.ExecuteNonQuery();
                    command.Connection.Close();
                }

                scope.Complete();
            }
        }
    }
}
