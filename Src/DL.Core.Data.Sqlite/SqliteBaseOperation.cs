using System;
using System.Data;
using System.Data.Common;

namespace DL.Core.Data.Sqlite
{
    public abstract class SqliteBaseOperation
    {
        protected SqliteBaseOperation(SqliteDataContext contextToUse)
        {
            this.DataContext = contextToUse;
        }

        protected SqliteDataContext DataContext { get; private set; }

        protected abstract void SetupParameters(DbCommand command);

        protected DbCommand SetupCommand(string commandText)
        {
            DbCommand command = this.DataContext.CreateCommand();
            command.CommandType = CommandType.Text;
            command.CommandText = commandText;
            this.SetupParameters(command);
            return command;
        }

        protected string StripGuidSymbols(Guid guid)
        {
            return guid.ToString()
                .TrimStart(new[] { '{' })
                .TrimEnd(new[] { '}' })
                .Replace("-", string.Empty);
        }

        protected Guid GetGuid(string guid)
        {
            if (!string.IsNullOrEmpty(guid))
            {
                return new Guid(guid);
            }

            return Guid.Empty;
        }

        protected DateTime? GetDateTime(string dateTime)
        {
            if (!string.IsNullOrEmpty(dateTime))
            {
                return DateTime.Parse(dateTime);
            }

            return null;
        }

        protected bool GetBool(long boolean)
        {
            return boolean == 1;
        }
    }
}
