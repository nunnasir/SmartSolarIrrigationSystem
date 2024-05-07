using System.Data;
using System.Data.SqlClient;

namespace SmartSolarIrrigationSystem.Application.Database;

public interface IDbConnectionFactory
{
    Task<IDbConnection> CreateConnectionAsync(CancellationToken token = default);
}

public class MSqlConnectionFactory : IDbConnectionFactory
{
    private readonly string _connectionString;

    public MSqlConnectionFactory(string connectionString)
    {
        _connectionString = connectionString;
    }

    public async Task<IDbConnection> CreateConnectionAsync(CancellationToken token = default)
    {
        var connection = new SqlConnection(_connectionString);
        await connection.OpenAsync(token);
        return connection;
    }
}

