using System.Collections.Generic;
using System.Data;
using System.Data.Common;

namespace DL.Core.Data.Sqlite
{
    public abstract class SqliteQueryOperation<T> : SqliteBaseOperation, IQueryOperation<T>
    {
        private readonly string commandText;

        protected SqliteQueryOperation(SqliteDataContext contextToUse, string commandTextToUse)
            : base(contextToUse)
        {
            this.commandText = commandTextToUse;
        }

        public IEnumerable<T> Execute()
        {
            var items = new List<T>();

            using (DbCommand command = this.SetupCommand(this.commandText))
            {
                this.DataContext.OpenConnection();

                using (IDataReader dataReader = command.ExecuteReader(CommandBehavior.CloseConnection))
                {
                    while (dataReader.Read())
                    {
                        T item = this.GetObjectFromDataReader(dataReader);
                        items.Add(item);
                    }
                }
            }

            return items;
        }

        protected abstract T GetObjectFromDataReader(IDataRecord dataRecord);
    }
}
