using Microsoft.EntityFrameworkCore.Metadata.Internal;
using RedisCachingSystem.LocalProgress.HelperServices.Abstract;
using RedisCachingSystem.LocalProgress.RedisValue;
using RedisCachingSystem.LocalProgress.Services.Abstract;

namespace RedisCachingSystem.LocalProgress.Cache;

public class CacheObject
{
    public string Key { get; set; }
    public CustomValue Value { get; set; }

    private readonly IHashService _hashService;
    private readonly IRedisService _redisService;

    public CacheObject(IHashService hashService, IRedisService redisService)
    {
        Key = string.Empty;

        _hashService = hashService;
        _redisService = redisService;
    }

    public CacheObject SetParams(object value)
    {
        var properties = value.GetType().GetProperties();

        foreach (var prop in properties)
        {
            var val = prop.GetValue(value);

            if (val is DateTime dateTimeValue)
            {
                val = dateTimeValue.ToString("dd.MM.yyyy");
            }

            Key += $"{prop.Name.ToLower()}:{val.ToString().ToLower()}&*";
        }

        if (Key.Length > 32)
        {
            Key = _hashService.HashString(Key);
        }

        return this;
    }

    public CacheObject SetKey(string key)
    {
        Key = key;

        return this;
    }

    public CacheObject SetValue(CustomValue value)
    {
        Value = value; 
        
        return this;
    }

    public async Task<bool> BuildCache()
    {
        return await _redisService.SetData(Key, Value);
    }
}
