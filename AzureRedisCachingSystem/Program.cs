using AzureRedisCachingSystem.Data;
using AzureRedisCachingSystem.Models.Misc;
using AzureRedisCachingSystem.Repositories.Abstract;
using AzureRedisCachingSystem.Repositories;
using AzureRedisCachingSystem.Services;

class Program
{
    static async Task Main(string[] args)
    {
        AppDbContext _dbContext = new AppDbContext();
        string _conStr = DbService.GetConnectionString();

        ICacheObjectRepository _cacheObjectRepo = new CacheObjectRepository();

        var result = await _cacheObjectRepo.UserCacheObject.SetCacheDataAsync();

        var obj = await _cacheObjectRepo.UserCacheObject.GetValueAsync<KValue<object>>();
    }
}
