namespace RedisCachingSystem.LocalProgress.RedisValue;

public class CustomValue
{
    public object Value { get; set; }
    
    public CustomValue(object value)
    {
        Value = value;
    }
}
