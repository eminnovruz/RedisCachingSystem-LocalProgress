using Microsoft.Extensions.Configuration;

namespace AzureRedisCachingSystem.Services;

public static class DbService
{
    public static string GetConnectionString()
    {
        var configuration = new ConfigurationBuilder()
            .SetBasePath(AppContext.BaseDirectory)
            .AddJsonFile("appsettings.json", optional: true)
            .Build();

        return configuration.GetConnectionString("Redis");
    }

}
