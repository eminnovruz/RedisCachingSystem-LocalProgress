namespace AzureRedisCachingSystem.Services.Abstract;

public interface IHashService
{
    string HashString(string input);
}
