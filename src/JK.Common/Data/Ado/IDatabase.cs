using System;
using System.Data;

namespace JK.Common.Data.Ado;

public interface IDatabase : IDisposable
{
    IDbCommand MakeCommand();
    int RunExecuteNonQuery(IDbCommand command);
    IDataReader RunExecuteReader(IDbCommand command, CommandBehavior behavior);
    object? RunExecuteScaler(IDbCommand command);
}
