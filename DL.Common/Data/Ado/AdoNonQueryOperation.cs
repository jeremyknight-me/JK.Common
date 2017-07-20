using System.Data;
using System.Data.Common;
using System.Transactions;
using DL.Common.Data.Contracts;

namespace DL.Common.Data.Ado
{
    public abstract class AdoNonQueryOperation : AdoBaseOperation, INonQueryOperation
    {
        private readonly CommandType commandType;

        private readonly string commandText;

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
                using (DbConnection connection = this.Repository.GetConnection())
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
