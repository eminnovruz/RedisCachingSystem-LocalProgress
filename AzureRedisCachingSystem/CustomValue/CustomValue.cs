namespace RedisCachingSystem.LocalProgress.RedisValue;

public class CustomValue
{
    public object Value { get; set; }
    public string SecretName { get; set; }
    
    public CustomValue(object value, string secretName)
    {
        Value = value;
        SecretName = secretName;
    }

    public override string ToString()
    {
        return $"{SecretName}/{Value}";
    }
}
