using Newsletter.Api;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

Log.Logger = new LoggerConfiguration()
    .WriteTo.Console()
    .CreateBootstrapLogger();

Log.Information("Starting up application...");

try
{
    builder.ConfigureServices()
           .Build()
           .ConfigureApplication()
           .Run();
}
catch (Exception ex)
{ 
    Log.Information(ex.ToString(), "Failed to start!");
}
finally
{
    Log.Information("Shutting down");
    Log.CloseAndFlush();
}