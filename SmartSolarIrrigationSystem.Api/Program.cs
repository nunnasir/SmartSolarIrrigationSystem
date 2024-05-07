using SmartSolarIrrigationSystem.Mqtt;
using SmartSolarIrrigationSystem.Application;
using SmartSolarIrrigationSystem.Mqtt.Models;
using SmartSolarIrrigationSystem.Application.Database;

var builder = WebApplication.CreateBuilder(args);
var config = builder.Configuration;

// Add services to the container.
builder.Services.AddControllers();

builder.Services.Configure<MqttSettings>(config.GetSection("MqttSettings"));

builder.Services.AddMqtt();
builder.Services.AddApplication();

builder.Services.AddDatabase(config["Database:ConnectionString"]!);

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

var dbInitializer = app.Services.GetRequiredService<DbInitializer>();
await dbInitializer.InitializeAsync();

app.Run();
