using AzureRedisCachingSystem.Cache.Metrics;
using AzureRedisCachingSystem.Configurations;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using Serilog;

namespace AzureRedisCachingSystem.Data;

public class MongoDbContext
{
    private readonly IMongoDatabase _database;

    public MongoDbContext(IOptions<MongoDbConfiguration> settings)
    {
        MongoClient client = new MongoClient(settings.Value.ConnectionString);

        _database = client.GetDatabase(settings.Value.DatabaseName);
    }

    public IMongoCollection<CacheMetrics> Metrics => _database.GetCollection<CacheMetrics>("metrics");
}
