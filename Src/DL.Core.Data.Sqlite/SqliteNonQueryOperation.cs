using System;
using System.Data.Common;

namespace DL.Core.Data.Sqlite
{
    public abstract class SqliteNonQueryOperation : SqliteBaseOperation, INonQueryOperation
    {
        private readonly string commandText;

        protected SqliteNonQueryOperation(SqliteDataContext contextToUse, string commandTextToUse)
            : base(contextToUse)
        {
            this.commandText = commandTextToUse;
        }

        public void Execute()
        {
            using (DbCommand command = this.SetupCommand(this.commandText))
            {
                this.DataContext.OpenConnection();
                this.DataContext.StartTransaction();

                try
                {
                    command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    this.DataContext.AddException(ex);
                }
            }
        }
    }
}
