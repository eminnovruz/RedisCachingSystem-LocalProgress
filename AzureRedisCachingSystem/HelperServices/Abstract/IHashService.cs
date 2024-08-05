namespace RedisCachingSystem.LocalProgress.HelperServices.Abstract;

public interface IHashService
{
    Task<string> HashString(string input);
}
