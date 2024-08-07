namespace AzureRedisCachingSystem.ApplicationModels;

public class Book
{
    public string Id { get; set; }
    public string Title  { get; set; }
    public DateTime PublishDate { get; set; }
    public int Price { get; set; }
}
