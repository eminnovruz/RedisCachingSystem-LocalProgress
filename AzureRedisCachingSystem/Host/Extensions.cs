using AzureRedisCachingSystem.Configurations.Redis;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using RedisCachingSystem.LocalProgress.HelperServices.Abstract;
using RedisCachingSystem.LocalProgress.HelperServices;
using RedisCachingSystem.LocalProgress.Services.Abstract;
using RedisCachingSystem.LocalProgress.Services;

public static class HostExtensions
{
    public static IHostBuilder ConfigureAppServices(this IHostBuilder hostBuilder)
    {
        return hostBuilder
            .ConfigureAppConfiguration((context, config) =>
            {
                config.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
            })
            .ConfigureServices((context, services) =>
            {
                services.Configure<RedisConfig>(context.Configuration.GetSection("Redis"));

                services.AddScoped<IRedisService, RedisService>();
                services.AddScoped<IHashService, HashService>();
            });
    }
}
