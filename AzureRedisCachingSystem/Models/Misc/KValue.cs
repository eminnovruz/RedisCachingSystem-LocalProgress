namespace AzureRedisCachingSystem.Models.Misc;

public class KValue<T>
{
    public T Value { get; set; }

    public KValue(T value)
    {
        Value = value;
    }

    // Other props here

}
