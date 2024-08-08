using AzureRedisCachingSystem.Adapters.RedisReader;
using AzureRedisCachingSystem.Adapters.RedisWriter;
using AzureRedisCachingSystem.ApplicationModels;
using AzureRedisCachingSystem.Cache.CustomValues;
using AzureRedisCachingSystem.Cache.Entries;
using AzureRedisCachingSystem.Cache.Settings;
using AzureRedisCachingSystem.Configurations;
using AzureRedisCachingSystem.Data;
using AzureRedisCachingSystem.Services;
using AzureRedisCachingSystem.Services.Abstract;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

//////////////////////////////////////// Dependency Injection

var host = Host.CreateDefaultBuilder(args)
.ConfigureAppConfiguration((context, config) =>
{
    config.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
})
.ConfigureServices((context, services) =>
{
    services.Configure<RedisConfig>(context.Configuration.GetSection("Redis"));
    services.Configure<MongoDbConfiguration>(context.Configuration.GetSection("MongoDB"));
    services.AddScoped<IRedisService, RedisService>();
    services.AddScoped<IMetricsService, MetricsService>();
    services.AddSingleton<MongoDbContext>();
})
.Build();

//////////////////////////////////////// Fake data

List<Book> books = new List<Book>()
{
    new Book
    {
        Id = Guid.NewGuid().ToString(),
        Price = 15,
        PublishDate = DateTime.Now,

        Title = "Nagil 101"
    },
    new Book
    {
        Id = Guid.NewGuid().ToString(),
        Price = 15,
        PublishDate = DateTime.Now,
        Title = "Nagil 101"
    },
    new Book
    {
        Id = Guid.NewGuid().ToString(),
        Price = 15,
        PublishDate = DateTime.Now,
        Title = "Nagil 101"
    },
    new Book
    {
        Id = Guid.NewGuid().ToString(),
        Price = 15,
        PublishDate = DateTime.Now,
        Title = "Nagil 101"

    },
};

/////////////////////////////////////// Application

IRedisService redisService = host.Services.GetRequiredService<IRedisService>();
IMetricsService metricsService = host.Services.GetRequiredService<IMetricsService>();

/////////////////////////////////////// Write sample

RedisWriter writerAdapter = new RedisWriter(redisService, metricsService);

CacheValue bookCacheValue = new CacheValue()
{
    Value = 31697252,
};

CacheEntry bookCache = new CacheEntryConfigurer()
    .SetKey("Salamqaqa")
    .SetValue(bookCacheValue)
    .SetExpire(DateTimeOffset.UtcNow.AddHours(1))
    .BuildCacheEntry();

await writerAdapter.WriteToCache(bookCache);

/////////////////////////////////////// Read sample

// cc8687825c8a2556c011e8f6a77f81a0 

try
{
    RedisReader reader = new RedisReader(redisService,metricsService);

    CacheValue responseValue = await reader.ReadFromCacheAsync("Salamqaqa");

    Console.WriteLine(responseValue.Value);
}
catch (Exception exception)
{
    Console.WriteLine(exception.Message);
}


