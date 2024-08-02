using AzureRedisCachingSystem.Configurations.MongoDb;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using Serilog;

namespace AzureRedisCachingSystem.Data;

public class MongoDbContext
{
    private readonly IMongoDatabase _database;

    public MongoDbContext(IOptions<MongoDbConfiguration> options)
    {
        MongoClient client = new MongoClient(options.Value.ConnectionString);

        _database = client.GetDatabase(options.Value.DatabaseName);

        Log.Information("Database connected successfully");
    }

    public IMongoClient 
}
