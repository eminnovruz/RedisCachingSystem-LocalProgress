using Microsoft.Extensions.Configuration;
using Serilog;

namespace AzureRedisCachingSystem.Services;

public static class AppService
{
    public static string GetConnectionString()
    {
        var configuration = new ConfigurationBuilder()
            .SetBasePath(AppContext.BaseDirectory)
            .AddJsonFile("appsettings.json", optional: true)
            .Build();

        return configuration.GetConnectionString("Redis");
    }

    public static void ConfigureLogging()
    {
        Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Debug()
                .WriteTo.Console()
                .CreateLogger();
    }

}
