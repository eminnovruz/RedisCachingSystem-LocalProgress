using AzureRedisCachingSystem.Cache.CustomValues;
using AzureRedisCachingSystem.HelperServices.UniqueKey;
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

        CacheValue cacheValue = JsonConvert.DeserializeObject<CacheValue>(responseValue);

        if (cacheValue == null)
            throw new Exception("Error occurred while casting type");

        return cacheValue;
    }

    public async Task<CacheValue> ReadFromCacheViaParametersAsync(object parameter)
    {
        string key = string.Empty;
        
        UniqueKeyService.GenerateUniqueKeyViaParams(ref key, parameter);

        return await ReadFromCacheAsync(key);
    }
}
