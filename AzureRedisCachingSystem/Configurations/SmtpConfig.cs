namespace AzureRedisCachingSystem.Configurations;

public class SmtpConfig
{
    public string Host { get; set; }
    public int Port { get; set; }
    public string FromAddress { get; set; }
    public string Username { get; set; }
    public string Password { get; set; }
}
