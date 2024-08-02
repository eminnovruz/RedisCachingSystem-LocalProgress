namespace RedisCachingSystem.LocalProgress.RedisValue;

public class CustomValue<T>
{
    public T Value { get; set; }
    public string SecretName { get; set; }
}
