using AzureRedisCachingSystem.Configurations.Redis;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using RedisCachingSystem.LocalProgress.HelperServices;
using RedisCachingSystem.LocalProgress.HelperServices.Abstract;
using RedisCachingSystem.LocalProgress.RedisValue;
using RedisCachingSystem.LocalProgress.Services;
using RedisCachingSystem.LocalProgress.Services.Abstract;
using System.Text.Json;

namespace RedisCachingSystem.LocalProgress;

class Program
{
    static async Task Main(string[] args)
    {
        try
        {
            IHost host = Host.CreateDefaultBuilder(args)
            .ConfigureAppConfiguration((context, config) =>
            {
                config.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
            })
            .ConfigureServices((context, services) =>
            {
                services.Configure<RedisConfig>(context.Configuration.GetSection("Redis"));

                services.AddScoped<IRedisService, RedisService>();
                services.AddScoped<IHashService, HashService>();
            })
            .Build();

            IRedisService redis = host.Services.GetRequiredService<IRedisService>();

            await redis.SetData("salamalekuma", new CustomValue(
                new List<string>()
                {
                    "aue",
                    "aue",
                    "aue",
                    "aue",
                    "aue",
                    "aue",
                    "aue",
                    "aue",
                    "aue",
                }
                ));
        }
        catch (Exception exception)
        {
            throw new Exception(exception.Message);
        }
        
    }
}
