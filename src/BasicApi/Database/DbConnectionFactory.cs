using System.Data;
using Microsoft.Extensions.Options;
using Npgsql;

namespace BasicApi.Database;

public class DbConnectionFactory(IOptions<DatabaseOptions> options) : IDbConnectionFactory
{
    private readonly IOptions<DatabaseOptions> _options = options;
    
    public async Task<IDbConnection> Create(CancellationToken token = default)
    {
        var connection = new NpgsqlConnection($"Host={_options.Value.Host};Username={_options.Value.User};Password={_options.Value.Password};Database=basic");
        await connection.OpenAsync(token);
        return connection;
    }
}