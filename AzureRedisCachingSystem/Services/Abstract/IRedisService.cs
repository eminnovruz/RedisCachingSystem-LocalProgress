﻿using RedisCachingSystem.LocalProgress.RedisValue;

namespace RedisCachingSystem.LocalProgress.Services.Abstract;

public interface IRedisService
{
    Task<bool> SetData(string key, CustomValue value);
    Task<StackExchange.Redis.RedisValue> GetData(string key);
    Task<bool> CheckIfExist(string key);
}