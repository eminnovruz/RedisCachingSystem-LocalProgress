using AzureRedisCachingSystem.Configurations.Redis;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using RedisCachingSystem.LocalProgress.RedisValue;
using RedisCachingSystem.LocalProgress.Services;
using RedisCachingSystem.LocalProgress.Services.Abstract;
using System.Text.Json;
using System.Text.Json.Serialization.Metadata;

namespace RedisCachingSystem.LocalProgress;

class Program
{
    static async Task Main(string[] args)
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

        StackExchange.Redis.RedisValue redisValue = await redis.GetData("salamlarolsun");

        if(redisValue.HasValue)
        {
            string jsonStr = redisValue.ToString();

            CustomValue customValue = new CustomValue(
                value: JsonSerializer.Deserialize<object>(jsonStr)
                );

            Console.WriteLine(customValue.Value);
        }
    }
}
