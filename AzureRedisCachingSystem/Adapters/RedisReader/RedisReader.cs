using AzureRedisCachingSystem.Cache.CustomValues;
using AzureRedisCachingSystem.HelperServices.UniqueKey;
using AzureRedisCachingSystem.Services.Abstract;
using Newtonsoft.Json;
using StackExchange.Redis;

namespace AzureRedisCachingSystem.Adapters.RedisReader;

public class RedisReader
{
    private readonly IRedisService redisService;
    private readonly IMetricsService metricsService;

    public RedisReader(IRedisService redisService, IMetricsService metricsService)
    {
        this.redisService = redisService;
        this.metricsService = metricsService;
    }

    public async Task<CacheValue> ReadFromCacheAsync(string key)
    {
        RedisValue responseValue = await redisService.ReadFromRedis(key);

        if (!responseValue.HasValue)
        {
            await metricsService.HandleCacheMiss(key);
            throw new Exception("Cannot find value related with given key");
        }

        CacheValue cacheValue = JsonConvert.DeserializeObject<CacheValue>(responseValue);

        if (cacheValue == null)
            throw new Exception("Error occurred while casting type");

        await metricsService.HandleCacheHit(key);

        return cacheValue;
    }

    public async Task<CacheValue> ReadFromCacheViaParametersAsync(object parameter)
    {
        string key = string.Empty;
        
        UniqueKeyService.GenerateUniqueKeyViaParams(ref key, parameter);

        return await ReadFromCacheAsync(key);
    }
}
