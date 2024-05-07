using Dapper;
using SmartSolarIrrigationSystem.Application.Database;
using SmartSolarIrrigationSystem.Application.Model;

namespace SmartSolarIrrigationSystem.Application.Repositories;

public class DeviceDataRepository : IDeviceDataRepository
{
    private readonly IDbConnectionFactory _dbConnectionFactory;

    public DeviceDataRepository(IDbConnectionFactory connectionFactory)
    {
        _dbConnectionFactory = connectionFactory;
    }

    public async Task<bool> CreateAsync(DeviceData deviceData, CancellationToken token = default)
    {
        using var connection = await _dbConnectionFactory.CreateConnectionAsync(token);

        var result = await connection.ExecuteAsync(new CommandDefinition("""
            insert into IotDeviceData (Id, Ph, Mos, Nit, Phos, Pot, Water, Wfr, Node, Sensor, CreatedTime)
            values (@Id, @Ph, @Mos, @Nit, @Phos, @Pot, @Water, @Wfr, @Node, @Sensor, @CreatedTime)
            """, deviceData, cancellationToken: token));

        return result > 0;
    }

    public async Task<DeviceData?> GetLastData(CancellationToken token = default)
    {
        using var connection = await _dbConnectionFactory.CreateConnectionAsync(token);
        var deviceData = await connection.QuerySingleOrDefaultAsync<DeviceData>(
            new CommandDefinition("""
                select top (1) dt.* 
                from IotDeviceData dt
                order by CreatedTime desc
                """, cancellationToken: token));

        if (deviceData is null)
        {
            return null;
        }

        return deviceData;
    }
}