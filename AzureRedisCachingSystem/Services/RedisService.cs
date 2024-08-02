using RedisCachingSystem.LocalProgress.RedisValue;
using RedisCachingSystem.LocalProgress.Services.Abstract;

namespace RedisCachingSystem.LocalProgress.Services;

public class RedisService : IRedisService<object>
{


    public Task<bool> CheckIfExist(string key)
    {
        throw new NotImplementedException();
    }

    public Task<CustomValue<object>> GetData()
    {
        throw new NotImplementedException();
    }

    public Task<bool> SetData(string key, CustomValue<object> value)
    {
        throw new NotImplementedException();
    }
}
