using SmartSolarIrrigationSystem.Mqtt;
using SmartSolarIrrigationSystem.Mqtt.Models;

var builder = WebApplication.CreateBuilder(args);
var config = builder.Configuration;

// Add services to the container.
builder.Services.AddControllers();

builder.Services.Configure<MqttSettings>(config.GetSection("MqttSettings"));

builder.Services.AddMqtt();

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
