using Dapper;
using SmartSolarIrrigationSystem.Application.Database;
using SmartSolarIrrigationSystem.Application.Model;

namespace SmartSolarIrrigationSystem.Application.Repositories;

public class StandardDataRepository : IStandardDataRepository
{
    private readonly IDbConnectionFactory _dbConnectionFactory;

    public StandardDataRepository(IDbConnectionFactory dbConnectionFactory)
    {
        _dbConnectionFactory = dbConnectionFactory;
    }

    public async Task<bool> CreateAsync(StandardValue standardValue, CancellationToken token = default)
    {
        using var connection = await _dbConnectionFactory.CreateConnectionAsync(token);

        var result = await connection.ExecuteAsync(new CommandDefinition("""
            insert into StandardValue (Id, Ph, Mos, Nit, Phos, Pot, Water, Wfr, Node, FieldInfoId, CreatedTime)
            values (@Id, @Ph, @Mos, @Nit, @Phos, @Pot, @Water, @Wfr, @Node, @FieldInfoId, @CreatedTime)
            """, standardValue, cancellationToken: token));

        return result > 0;
    }

    public async Task<bool> DeleteByIdAsync(Guid id, CancellationToken token = default)
    {
        using var connection = await _dbConnectionFactory.CreateConnectionAsync(token);

        var result = await connection.ExecuteAsync(new CommandDefinition("""
            delete from StandardValue where id = @id
            """, new { id }, cancellationToken: token));

        return result > 0;
    }

    public async Task<IEnumerable<StandardValue>> GetAllAsync(CancellationToken token = default)
    {
        using var connection = await _dbConnectionFactory.CreateConnectionAsync(token);
        var result = await connection.QueryAsync(new CommandDefinition("""
            SELECT sv.id, 
                   sv.ph, 
                   sv.mos, 
                   sv.nit, 
                   sv.phos, 
                   sv.pot, 
                   sv.water, 
                   sv.wfr, 
                   sv.node, 
                   sv.fieldInfoId,
                   fi.fieldId, 
                   fi.name
            FROM StandardValue sv 
            JOIN FieldInfo fi ON sv.FieldInfoId = fi.id
            """, cancellationToken: token));

        var response = result.Select(x => new StandardValue
        {
            Id = x.id,
            Ph = x.ph,
            Mos = x.mos,
            Nit = x.nit,
            Phos = x.phos,
            Pot = x.pot,
            Water = x.water,
            Wfr = x.wfr,
            Node = x.node,
            FieldInfoId = x.fieldInfoId,
            FieldId = x.fieldId,
            FieldName = x.name,
        });

        return response;
    }

    public async Task<StandardValue?> GetByFielIdAsync(Guid fieldId, CancellationToken token = default)
    {
        using var connection = await _dbConnectionFactory.CreateConnectionAsync(token);

        var standardData = await connection.QuerySingleOrDefaultAsync<StandardValue>(
            new CommandDefinition("""
                SELECT sv.id, 
                       sv.ph, 
                       sv.mos, 
                       sv.nit, 
                       sv.phos, 
                       sv.pot, 
                       sv.water, 
                       sv.wfr, 
                       sv.node, 
                       sv.fieldInfoId,
                       fi.fieldId, 
                       fi.name
                FROM StandardValue sv
                JOIN FieldInfo fi ON sv.FieldInfoId = fi.id
                where sv.FieldInfoId = @fieldId
                """, new { fieldId }, cancellationToken: token));

        if (standardData is null)
        {
            return null;
        }

        return standardData;
    }

    public async Task<StandardValue?> GetByIdAsync(Guid id, CancellationToken token = default)
    {
        using var connection = await _dbConnectionFactory.CreateConnectionAsync(token);

        var standardData = await connection.QuerySingleOrDefaultAsync<StandardValue>(
            new CommandDefinition("""
                SELECT sv.id, 
                       sv.ph, 
                       sv.mos, 
                       sv.nit, 
                       sv.phos, 
                       sv.pot, 
                       sv.water, 
                       sv.wfr, 
                       sv.node, 
                       sv.fieldInfoId,
                       fi.fieldId, 
                       fi.name
                FROM StandardValue sv
                JOIN FieldInfo fi ON sv.FieldInfoId = fi.id
                where sv.id = @id
                """, new { id }, cancellationToken: token));

        if (standardData is null)
        {
            return null;
        }

        return standardData;
    }

    public async Task<bool> UpdateAsync(StandardValue standardValue, CancellationToken token = default)
    {
        using var connection = await _dbConnectionFactory.CreateConnectionAsync(token);

        var result = await connection.ExecuteAsync(new CommandDefinition("""
            update StandardValue set Ph = @Ph, mos = @Mos, nit = @Nit, phos = @Phos, pot = @Pot, water = @Water, wfr = @Wfr, updatedTime = @UpdatedTime
            where id = @Id
            """, standardValue, cancellationToken: token));

        return result > 0;
    }
}
