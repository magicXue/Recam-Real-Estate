namespace RealEstateMediaPlatform.API.Models;

public class Property
{
    public int Id { get; set; }

    public string Title { get; set; } = default!;

    public string Address { get; set; } = default!;

    public decimal Price { get; set; }

    public DateTime CreatedAt { get; set; }
}