using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileProviders;
using Quiz.Service.Data;
using Quiz.Service;
using Microsoft.ApplicationInsights.Extensibility;
using Quiz.Service.Resources;
using System.Configuration;
using Quiz.Service.Configuration;

var builder = WebApplication.CreateBuilder(args);
Console.WriteLine(Instance.ContainerId);

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddApplicationInsightsTelemetry();

builder.Services.AddApplicationInsightsTelemetry();
builder.Services.Configure<WebAppSettings>(builder.Configuration.GetSection("webAppSettings"));
builder.Services.Configure<Database>(builder.Configuration.GetSection("Database"));

builder.Services.AddSingleton<ITelemetryInitializer, CustomTelemetryInitializer>();

var aaa = builder.Configuration.GetConnectionString("MySqlConnection");

Console.WriteLine($"***Environment ****{Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT")}");

// if (Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") == "devaks")
// {
Console.WriteLine("***Inside devaks****");
var server = Environment.GetEnvironmentVariable("DB_HOSTNAME");
var port = Environment.GetEnvironmentVariable("DB_PORT");
var db = Environment.GetEnvironmentVariable("DB_NAME");
var user = Environment.GetEnvironmentVariable("DB_USERNAME");
var pwd = Environment.GetEnvironmentVariable("DB_PASSWORD");

var connectionStr = $"Server={server}; Port={port}; Database={db}; Uid={user}; Pwd={pwd};";
Console.WriteLine($"***Environment Connection string ****{connectionStr}");
builder.Services.AddDbContext<QuizDbContext>(options => options.UseMySQL(connectionStr));
// }
// else
// {
//     Console.WriteLine($"*** not devaks ****");
//     builder.Services.AddDbContext<QuizDbContext>(options => options.UseMySQL(builder.Configuration.GetConnectionString("MySqlConnection")));
// }

var app = builder.Build();

//app.UsePathBase("/quizsvc");

app.UseCors(builder =>
  builder.WithOrigins("http://localhost:3000")
         .AllowAnyHeader()
         .AllowAnyMethod()
         .AllowAnyOrigin()
         );

app.UseStaticFiles(new StaticFileOptions
{
    FileProvider = new PhysicalFileProvider(
        Path.Combine(builder.Environment.ContentRootPath, "Images")),
    RequestPath = "/Images"
});

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var context = services.GetRequiredService<QuizDbContext>();
    try
    {
        DBInitializer.Initialize(context);
    }
    catch (Exception ex)
    {
        Console.WriteLine(ex.Message);
        app.Logger.LogError(ex, $"Unable to connect db {0}", context.Database.GetConnectionString());
    }
}

// Configure the HTTP request pipeline.
if (app.Environment.EnvironmentName == "dev" || app.Environment.EnvironmentName == "local")
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();
app.Run();