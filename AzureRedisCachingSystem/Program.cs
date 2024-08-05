using AzureRedisCachingSystem.Configurations.Redis;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
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

                services.AddSingleton<IRedisService, RedisService>();
            })
            .Build();

            IRedisService redis = host.Services.GetRequiredService<IRedisService>();

            CustomValue customValue = await redis.GetData("salamlarolsun");

            Console.WriteLine(customValue.Value);
        }
        catch (Exception exception)
        {
            throw new Exception(exception.Message);
        }
        
    }
}
