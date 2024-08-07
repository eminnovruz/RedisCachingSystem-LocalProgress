using AzureRedisCachingSystem.Cache.Entries;
using AzureRedisCachingSystem.Services.Abstract;

namespace AzureRedisCachingSystem.Adapters.RedisWriter;

public class RedisWriter
{
    private readonly IRedisService redisService;

    public RedisWriter(IRedisService redisService)
    {
        this.redisService = redisService;
    }

    public async Task<bool> WriteToCache(CacheEntry entry)
    {
        bool writeResult = await redisService.WriteToRedis(entry);

        return writeResult;
    }
}
