using Dapper;
using SmartSolarIrrigationSystem.Application.Database;
using SmartSolarIrrigationSystem.Application.Model;

namespace SmartSolarIrrigationSystem.Application.Repositories;

public class FieldInfoRepository : IFieldInfoRepository
{
    private readonly IDbConnectionFactory _dbConnectionFactory;

    public FieldInfoRepository(IDbConnectionFactory connectionFactory)
    {
        _dbConnectionFactory = connectionFactory;
    }

    public async Task<bool> CreateAsync(FieldInfo fieldInfo, CancellationToken token = default)
    {
        using var connection = await _dbConnectionFactory.CreateConnectionAsync(token);

        var result = await connection.ExecuteAsync(new CommandDefinition("""
            insert into FieldInfo (Id, FieldId, Name, CreatedTime)
            values (@Id, @FieldId, @FieldName, @CreatedTime)
            """, fieldInfo, cancellationToken: token));

        return result > 0;
    }

    public async Task<bool> DeleteByIdAsync(Guid id, CancellationToken token = default)
    {
        using var connection = await _dbConnectionFactory.CreateConnectionAsync(token);
        using var transaction = connection.BeginTransaction();

        await connection.ExecuteAsync(new CommandDefinition("""
            delete from StandardValue where FieldInfoId = @id
            """, new { id }, transaction, cancellationToken: token));

        var result = await connection.ExecuteAsync(new CommandDefinition("""
            delete from FieldInfo where id = @id
            """, new { id }, transaction, cancellationToken: token));

        transaction.Commit();

        return result > 0;
    }

    public async Task<IEnumerable<FieldInfo>> GetAllAsync(CancellationToken token = default)
    {
        using var connection = await _dbConnectionFactory.CreateConnectionAsync(token);

        var result = await connection.QueryAsync(new CommandDefinition("""
            SELECT fi.Id, 
                   fi.FieldId, 
                   fi.Name 
            FROM FieldInfo fi 
            """, cancellationToken: token));

        var response = result.Select(x => new FieldInfo
        {
            Id = x.Id,
            FieldId = x.FieldId,
            FieldName = x.Name,
        });

        return response;
    }

    public async Task<FieldInfo?> GetByIdAsync(Guid id, CancellationToken token = default)
    {
        using var connection = await _dbConnectionFactory.CreateConnectionAsync(token);

        var fieldInfo = await connection.QuerySingleOrDefaultAsync<FieldInfo>(
            new CommandDefinition("""
                SELECT fi.Id, 
                       fi.FieldId, 
                       fi.Name AS FieldName
                FROM FieldInfo fi
                where fi.Id = @id
                """, new { id }, cancellationToken: token));

        if (fieldInfo is null)
        {
            return null;
        }

        return fieldInfo;
    }

    public async Task<bool> UpdateAsync(FieldInfo fieldInfo, CancellationToken token = default)
    {
        using var connection = await _dbConnectionFactory.CreateConnectionAsync(token);

        var result = await connection.ExecuteAsync(new CommandDefinition("""
            update FieldInfo set FieldId = @FieldId, Name = @FieldName, UpdatedTime = @UpdatedTime
            where id = @Id
            """, fieldInfo, cancellationToken: token));

        return result > 0;
    }
}
