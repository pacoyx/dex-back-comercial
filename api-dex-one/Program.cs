var builder = WebApplication.CreateBuilder(args);
var logger = LoggerFactory.Create(builder => builder.AddConsole()).CreateLogger<Program>();

Startup.ConfigureServices(builder.Services, builder.Configuration, logger);
var app = builder.Build();
Startup.Configure(app, app.Environment);

app.MapControllers();
app.Run();