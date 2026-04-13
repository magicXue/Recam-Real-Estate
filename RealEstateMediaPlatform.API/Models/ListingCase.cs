namespace RealEstateMediaPlatform.API.Models;

public class ListingCase
{
    public int Id { get; set; }

    public string Title { get; set; }
    public string Address { get; set; }

    public PropertyStatus Status { get; set; }
    public PropertyType Type { get; set; }

    public int Bedrooms { get; set; }
    public int Bathrooms { get; set; }
    public int Garage { get; set; }

    public double Area { get; set; }

    public decimal? Price { get; set; }

    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
    public string AgentId { get; internal set; }
}