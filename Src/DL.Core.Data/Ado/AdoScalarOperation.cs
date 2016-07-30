using System.Data;
using System.Data.Common;
using System.Transactions;

namespace DL.Core.Data.Ado
{
    /// <summary>
    /// Abstract base operation class which supports ADO Database scalar command operations.
    /// </summary>
    /// <typeparam name="T">Generic type to be returned from the scalar operation.</typeparam>
    public abstract class AdoScalarOperation<T> : AdoBaseOperation, IScalarOperation<T> where T : struct
    {
        private readonly CommandType commandType;

        private readonly string commandText;

        protected AdoScalarOperation(AdoBaseRepository adoBaseRepository, CommandType adoCommandType, string adoCommandText)
            : base(adoBaseRepository)
        {
            this.commandText = adoCommandText;
            this.commandType = adoCommandType;
        }

        public T Execute()
        {
            T value;

            using (var scope = new TransactionScope())
            {
                using (DbConnection connection = this.Repository.Connection)
                using (DbCommand command = this.SetupCommand(connection, this.commandType, this.commandText))
                {
                    command.Connection.Open();
                    object scalar = command.ExecuteScalar();
                    value = (T)scalar;
                    command.Connection.Close();
                }

                scope.Complete();
            }

            return value;
        }
    }
}
