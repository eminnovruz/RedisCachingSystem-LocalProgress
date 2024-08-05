using AzureRedisCachingSystem.Configurations.Redis;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using RedisCachingSystem.LocalProgress.Cache;
using RedisCachingSystem.LocalProgress.FilterModels;
using RedisCachingSystem.LocalProgress.HelperServices;
using RedisCachingSystem.LocalProgress.HelperServices.Abstract;
using RedisCachingSystem.LocalProgress.RedisValue;
using RedisCachingSystem.LocalProgress.Services;
using RedisCachingSystem.LocalProgress.Services.Abstract;

namespace RedisCachingSystem.LocalProgress;

class Program
{
    static async Task Main(string[] args)
    {
        var host = Host.CreateDefaultBuilder(args)
                .ConfigureAppServices()
                .Build();

        await host.RunAsync();


    }
}
