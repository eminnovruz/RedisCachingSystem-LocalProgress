using AzureRedisCachingSystem.Configurations;
using AzureRedisCachingSystem.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using Serilog;

namespace AzureRedisCachingSystem.Data;

public class MongoDbContext
{
    private readonly IMongoDatabase _database;

    public MongoDbContext(string conStr, string dbname)
    {
        MongoClient client = new MongoClient(conStr);

        _database = client.GetDatabase(dbname);
    }

    public IMongoCollection<Book> Books { get; set; }
}
