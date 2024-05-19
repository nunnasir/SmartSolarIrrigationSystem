using Dapper;

namespace SmartSolarIrrigationSystem.Application.Database;

public class DbInitializer
{
    private readonly IDbConnectionFactory _connectionFactory;

    public DbInitializer(IDbConnectionFactory connectionFactory)
    {
        _connectionFactory = connectionFactory;
    }

    public async Task InitializeAsync()
    {
        using var connection = await _connectionFactory.CreateConnectionAsync();

        await connection.ExecuteAsync("""
            IF NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_SCHEMA = 'dbo' AND TABLE_NAME = 'IotDeviceData')
            BEGIN
                CREATE TABLE IotDeviceData (
                   Id UNIQUEIDENTIFIER PRIMARY KEY,
                   Ph decimal(18,2) NOT NULL,
                   Mos decimal(18,2) NOT NULL,
                   Nit decimal(18,2) NOT NULL,
                   Phos decimal(18,2) NOT NULL,
                   Pot decimal(18,2) NOT NULL,
                   Water decimal(18,2) NOT NULL,
                   Wfr decimal(18,2) NOT NULL,
                   Node decimal(18,2) NOT NULL,
                   Sensor decimal(18,2) NOT NULL,
                   CreatedTime datetime2 NOT NULL
                );
            END;
        """);

        await connection.ExecuteAsync("""
            IF NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_SCHEMA = 'dbo' AND TABLE_NAME = 'FieldInfo')
            BEGIN
                CREATE TABLE FieldInfo (
                   Id UNIQUEIDENTIFIER PRIMARY KEY,
                   FieldId NVARCHAR(MAX) NOT NULL,
                   Name NVARCHAR(MAX) NOT NULL,
                   CreatedTime datetime2 NOT NULL,
                   UpdatedTime datetime2 NULL
                );
            END;
        """);

        await connection.ExecuteAsync("""
            IF NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_SCHEMA = 'dbo' AND TABLE_NAME = 'StandardValue')
            BEGIN
                CREATE TABLE StandardValue (
                   Id UNIQUEIDENTIFIER PRIMARY KEY,
                   Ph decimal(18,2) NOT NULL,
                   Mos decimal(18,2) NOT NULL,
                   Nit decimal(18,2) NOT NULL,
                   Phos decimal(18,2) NOT NULL,
                   Pot decimal(18,2) NOT NULL,
                   Water decimal(18,2) NOT NULL,
                   Wfr decimal(18,2) NOT NULL,
                   Node decimal(18,2) NOT NULL,
                   FieldInfoId UNIQUEIDENTIFIER references FieldInfo (id),
                   CreatedTime datetime2 NOT NULL,
                   UpdatedTime datetime2 NULL
                );
            END;
        """);
    }
}
