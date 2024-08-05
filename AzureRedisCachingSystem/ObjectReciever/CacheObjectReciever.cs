using Microsoft.EntityFrameworkCore.Metadata.Internal;
using RedisCachingSystem.LocalProgress.HelperServices;
using RedisCachingSystem.LocalProgress.HelperServices.Abstract;
using RedisCachingSystem.LocalProgress.RedisValue;
using RedisCachingSystem.LocalProgress.Services.Abstract;

namespace RedisCachingSystem.LocalProgress.ObjectReciever;

public class CacheObjectReciever
{
    private readonly IRedisService redisService;
    private readonly IHashService hashService;

    public CacheObjectReciever(IHashService hashService, IRedisService redisService)
    {
        this.hashService = hashService;
        this.redisService = redisService;
    }

    public async Task<CustomValue> GetValueViaKeyAsync(string key)
    {
        return await redisService.GetData(key);
    }

    public async Task<CustomValue> GetValueViaParams(object parameter)
    {
        var properties = parameter.GetType().GetProperties();

        string key = string.Empty;

        foreach (var prop in properties)
        {
            var val = prop.GetValue(parameter);

            if (val is DateTime dateTimeValue)
            {
                val = dateTimeValue.ToString("dd.MM.yyyy");
            }

            key += $"{prop.Name.ToLower()}:{val.ToString().ToLower()}&*";
        }

        if (key.Length > 32)
        {
            key = hashService.HashString(key);
        }

        return await GetValueViaKeyAsync(key);
    } 
}
