using System.Data;

namespace BasicApi.Database;

public interface IDbConnectionFactory
{
    Task<IDbConnection> Create(CancellationToken token = default);
}