using SmartSolarIrrigationSystem.Application;
using SmartSolarIrrigationSystem.Application.Database;
using SmartSolarIrrigationSystem.Mqtt;
using SmartSolarIrrigationSystem.Mqtt.Models;

var builder = WebApplication.CreateBuilder(args);
var config = builder.Configuration;

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

builder.Services.Configure<MqttSettings>(config.GetSection("MqttSettings"));

builder.Services.AddMqtt();
builder.Services.AddApplication();
builder.Services.AddDatabase(config["Database:ConnectionString"]!);

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowOrigin",
        builder =>
        {
            builder.WithOrigins("localhost:5173")
                   .AllowAnyHeader()
                   .AllowAnyMethod();

            //builder.WithOrigins("https://project-dashboard-roan.vercel.app")
            //       .AllowAnyHeader()
            //       .AllowAnyMethod();
        });
});

var app = builder.Build();

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseRouting();

app.UseCors("AllowOrigin");

app.UseAuthorization();

app.MapControllers();

var dbInitializer = app.Services.GetRequiredService<DbInitializer>();
await dbInitializer.InitializeAsync();

app.Run();
