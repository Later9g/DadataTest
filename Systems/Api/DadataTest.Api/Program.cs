using DadataTest.Api;
using DadataTest.Api.Configuration;
using DadataTest.Common.Exceptions;
using DadataTest.Services.Settings;
using DadataTest.Settings;

var mainSettings = Settings.Load<MainSettings>("Main");
var logSettings = Settings.Load<LogSettings>("Log");
var dadataSettings = Settings.Load<DadataSettings>("DadataSettings");

var builder = WebApplication.CreateBuilder(args);

builder.AddAppLogger(mainSettings, logSettings);

var services = builder.Services;

services.AddExceptionHandler<GlobalExceptionHandler>();
services.AddSingleton(dadataSettings);
services.AddAppCors();
services.RegisterAppServices();
services.AddControllers();
services.AddAppAutoMappers();
services.AddAppHealthChecks();

var app = builder.Build();

app.UseExceptionHandler();
app.UseAppCors();
app.MapControllers();
app.UseAppHealthChecks();

app.Run();
