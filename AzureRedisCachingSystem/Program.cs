using AzureRedisCachingSystem.Data;
using AzureRedisCachingSystem.Repositories;
using AzureRedisCachingSystem.Repositories.Abstract;

class Program
{
    static async Task Main(string[] args)
    {
        ICacheObjectRepository repo = new CacheObjectRepository();

        MongoDbContext context = new MongoDbContext("mongodb://localhost:27017", "myappdb");

        var response = await repo.BookCacheObject.GetValueAsync<object>();

        Console.WriteLine(response);
    }
}
    