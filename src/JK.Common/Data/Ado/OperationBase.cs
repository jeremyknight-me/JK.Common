using System.Data;

namespace JK.Common.Data.Ado
{
    public abstract class OperationBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="OperationBase"/> class.
        /// </summary>
        /// <param name="context">The ADO base data context to use.</param>
        protected OperationBase(DataContextBase context)
        {
            this.Context = context;
        }

        protected DataContextBase Context { get; }

        protected abstract void SetupParameters(IDbCommand command);

        protected IDbCommand SetupCommand(IDbConnection connection, CommandType commandType, string commandText)
        {
            var command = connection.CreateCommand();
            command.CommandType = commandType;
            command.CommandText = commandText;
            this.SetupParameters(command);
            return command;
        }
    }
}
