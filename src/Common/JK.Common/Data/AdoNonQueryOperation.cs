using JK.Common.Data.Contracts;
using System;
using System.Data;
using System.Data.Common;
using System.Transactions;

namespace JK.Common.Data
{
    [Obsolete("Generic ADO classes have not been tested in .NET Core. Left in for reference purposes.")]
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
