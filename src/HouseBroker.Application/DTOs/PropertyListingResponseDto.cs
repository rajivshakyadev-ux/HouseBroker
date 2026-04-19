namespace HouseBroker.Application.DTOs;

public class PropertyListingResponseDto
{
    public Guid Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public decimal Price { get; set; }
    public string Location { get; set; } = string.Empty;
    public string PropertyListingType { get; set; } = string.Empty;

    public decimal? BrokerCommission { get; set; }
}