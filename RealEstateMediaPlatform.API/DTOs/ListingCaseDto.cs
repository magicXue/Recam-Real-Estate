namespace RealEstateMediaPlatform.API.DTOs;

public class ListingCaseDto
{
    public int Id { get; set; }

    public string Title { get; set; } = null!;
    public string Address { get; set; } = null!;

    public int Bedrooms { get; set; }
    public decimal? Price { get; set; }

    public string AgentId { get; set; } = null!;
    public DateTime CreatedAt { get; set; }
}