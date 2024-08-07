using AzureRedisCachingSystem.Cache.Entries;

namespace AzureRedisCachingSystem.Services.Abstract;

public interface IRedisService
{
    Task<bool> WriteToRedis(CacheEntry entry);
}
