using System.Data;

namespace JK.Common.Data;

/// <summary>
/// Creates ADO.NET database connections.
/// </summary>
public interface IAdoConnectionFactory
{
    /// <summary>
    /// Creates and returns a new database connection.
    /// </summary>
    /// <returns>A new <see cref="IDbConnection"/> instance.</returns>
    IDbConnection Make();
}
