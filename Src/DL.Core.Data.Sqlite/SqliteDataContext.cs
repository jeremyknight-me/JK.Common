using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SQLite;
using System.Linq;

namespace DL.Core.Data.Sqlite
{
    public class SqliteDataContext : IUnitOfWork
    {
        private readonly List<Exception> exceptions;

        private readonly SQLiteConnection connection;

        private SQLiteTransaction transaction;        

        public SqliteDataContext(string path)
        {
            this.exceptions = new List<Exception>();
            var builder = new SQLiteConnectionStringBuilder { DataSource = path };
            this.connection = new SQLiteConnection(builder.ConnectionString);
            this.transaction = null;
        }

        public void AddException(Exception ex)
        {
            this.exceptions.Add(ex);
        }

        public void Dispose()
        {
            this.CloseConnection();
            this.transaction.Dispose();
            this.connection.Dispose();
        }

        public void Commit()
        {
            if (this.transaction != null)
            {
                if (this.exceptions.Any())
                {
                    this.transaction.Rollback();
                    var exception = this.exceptions.FirstOrDefault();
                    if (exception != null)
                    {
                        throw exception;
                    }
                }

                try
                {
                    this.transaction.Commit();
                }
                catch (Exception ex)
                {
                    this.transaction.Rollback();
                    throw ex;
                }

                this.CloseConnection();
            }           
        }

        public DbCommand CreateCommand()
        {
            return this.connection.CreateCommand();
        }

        public void OpenConnection()
        {
            if (this.connection.State != ConnectionState.Open)
            {
                this.connection.Open();
            }
        }

        public void StartTransaction()
        {
            if (this.transaction == null)
            {
                this.transaction = this.connection.BeginTransaction();
            }
        }

        private void CloseConnection()
        {
            if (this.connection.State != ConnectionState.Closed)
            {
                this.connection.Close();
            }
        }
    }
}
