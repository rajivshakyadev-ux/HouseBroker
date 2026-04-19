namespace HouseBroker.Domain.Entities;

public class PropertyListing
{
    public int Id { get; set; }
    public required string Title { get; set; }
    public string BrokerId { get; set; } = string.Empty;
    public decimal Price { get; set; }
    public string Location { get; set; } = string.Empty;
    public string PropertyListingType { get; set; } = string.Empty;
    public string Features { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public decimal BrokerCommission { get; set; }
    public DateTime CreatedAt { get; set; }
    public decimal CommissionAmount { get; set; }
    public ICollection<PropertyListingImage> Images { get; set; }
        = new List<PropertyListingImage>();
}