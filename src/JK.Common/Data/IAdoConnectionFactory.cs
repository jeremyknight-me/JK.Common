using System.Data;

namespace JK.Common.Data;

public interface IAdoConnectionFactory
{
    IDbConnection Make();
}
