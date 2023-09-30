using System.Data;

namespace JK.Common.Data.Ado;

public interface IAdoConnectionFactory
{
    IDbConnection Make();
}
