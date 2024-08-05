namespace AzureRedisCachingSystem.Models;

public class Contract
{
    public string ContractId { get; set; }
    public string Title { get; set; }
    public string Counterparty { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public decimal ContractValue { get; set; }
    public string Status { get; set; }
    public string Notes { get; set; }
}
