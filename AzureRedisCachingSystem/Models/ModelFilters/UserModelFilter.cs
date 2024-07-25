namespace AzureRedisCachingSystem.Models.ModelFilters;

public class UserModelFilter
{
    public string Id { get; set; }
    public string Name { get; set; }
    public string Surname { get; set; }
    public string Email { get; set; }
    public int Age { get; set; }
    public string PhoneNumber { get; set; }
    public string FacultyId { get; set; }
    public DateTime From { get; set; }
    public DateTime To { get; set; }
}
