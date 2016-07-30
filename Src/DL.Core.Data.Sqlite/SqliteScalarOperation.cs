using System.Data.Common;

namespace DL.Core.Data.Sqlite
{
    public abstract class SqliteScalarOperation<T> : SqliteBaseOperation, IScalarOperation<T> where T : struct
    {
        private readonly string commandText;

        protected SqliteScalarOperation(SqliteDataContext contextToUse, string commandTextToUse)
            : base(contextToUse)
        {
            this.commandText = commandTextToUse;
        }

        public T Execute()
        {
            T value;

            using (DbCommand command = this.SetupCommand(this.commandText))
            {
                this.DataContext.OpenConnection();
                object scalar = command.ExecuteScalar();
                value = (T)scalar;
            }

            return value;
        }
    }
}
