using AzureRedisCachingSystem.Cache.Entries;
using StackExchange.Redis;

namespace AzureRedisCachingSystem.Services.Abstract;

public interface IRedisService
{
    Task<bool> WriteToRedis(CacheEntry entry);
    Task<RedisValue> ReadFromRedis(string key);
}
