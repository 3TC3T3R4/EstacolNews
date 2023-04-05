

using System.Data;

namespace DrivenAdapterSQL.Gateway
{
    public interface IDbConnectionBuilder
    {
        Task<IDbConnection> CreateConnectionAsync();

    }
}
