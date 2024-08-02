using RedisCachingSystem.LocalProgress.RedisValue;

namespace RedisCachingSystem.LocalProgress.Services.Abstract;

public interface IRedisService<T>
{
    Task<bool> SetData(string key, CustomValue<T> value);
    Task<CustomValue<T>> GetData();
    Task<bool> CheckIfExist(string key);
}
