using Microsoft.Extensions.Configuration;
using Serilog;

namespace AzureRedisCachingSystem.Services
{
    /// <summary>
    /// Provides static methods for application configuration and logging setup.
    /// </summary>
    public static class AppService
    {
        /// <summary>
        /// Retrieves the Redis connection string from the application's configuration file.
        /// </summary>
        /// <returns>The Redis connection string.</returns>
        public static string GetConnectionString()
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(AppContext.BaseDirectory)
                .AddJsonFile("appsettings.json", optional: true)
                .Build();

            return configuration.GetConnectionString("Redis");
        }

        /// <summary>
        /// Configures the logging settings for the application using Serilog.
        /// </summary>
        public static void ConfigureLogging()
        {
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Debug()
                .WriteTo.Console()
                .CreateLogger();
        }
    }
}
