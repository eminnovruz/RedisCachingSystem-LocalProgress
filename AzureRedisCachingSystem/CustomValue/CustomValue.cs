namespace RedisCachingSystem.LocalProgress.RedisValue;

public class CustomValue
{
    public CustomValue(object value, string secretName)
    {
        Value = value;
        SecretName = secretName;
    }

    public object Value { get; set; }
    public string SecretName { get; set; }
}
