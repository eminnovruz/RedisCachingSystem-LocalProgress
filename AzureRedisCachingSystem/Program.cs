using AzureRedisCachingSystem.Data;
using AzureRedisCachingSystem.Models.Cache;
using AzureRedisCachingSystem.Models.Cache.Abstract;
using AzureRedisCachingSystem.Repositories;
using AzureRedisCachingSystem.Repositories.Abstract;
using AzureRedisCachingSystem.Services;

class Program
{
    static async Task Main(string[] args)
    {
        AppDbContext _dbContext = new AppDbContext();
        string _conStr = DbService.GetConnectionString();

        ICacheObjectRepository _cacheObjectRepo = new CacheObjectRepository();

        var result = await _cacheObjectRepo.UserCacheObject.SetCacheDataAsync();

        Console.WriteLine(result);

        var obj = await _cacheObjectRepo.UserCacheObject.GetValueAsync<int>();
    }
}
