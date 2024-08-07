using AzureRedisCachingSystem.Cache.CustomValues;
using AzureRedisCachingSystem.Services.Abstract;
using Newtonsoft.Json;
using StackExchange.Redis;

namespace AzureRedisCachingSystem.Adapters.RedisReader;

public class RedisReader
{
    private readonly IRedisService redisService;

    public RedisReader(IRedisService redisService)
    {
        this.redisService = redisService;
    }

    public async Task<CacheValue> ReadFromCacheAsync(string key)
    {
        RedisValue responseValue = await redisService.ReadFromRedis(key);

        if (!responseValue.HasValue)
            throw new Exception("Cannot find value related with given key");

        var obj = JsonConvert.DeserializeObject(responseValue);

        if (obj is CacheValue)
            throw new Exception("Error occured while casting type");

        return obj as CacheValue;
    } 
}
