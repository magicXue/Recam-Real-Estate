using System;

namespace RealEstateMediaPlatform.API.Models;

public class Agent
{
    public int Id { get; set; }

    public string Name { get; set; }

    public string Email { get; set; }

    public string AgencyName { get; set; }
    public bool IsActive { get; set; }
    public required ICollection<ListingCase> Listings { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
}
