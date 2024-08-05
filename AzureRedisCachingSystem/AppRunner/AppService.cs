using Microsoft.Extensions.Configuration;
using Serilog;

namespace AzureRedisCachingSystem.AppRunner
{
    
    public static class AppService
    {
        /// <summary>
        /// Configures the logging settings for the application using Serilog.
        /// </summary>
        public static void ConfigureLogging()
        {
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Warning()
                .WriteTo.Console()
                .CreateLogger();
        }
    }
}
