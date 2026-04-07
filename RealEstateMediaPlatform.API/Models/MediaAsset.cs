using System;

namespace RealEstateMediaPlatform.API.Models;

public class MediaAsset
{
    public Guid Id { get; set; }

    public Guid ListingId { get; set; }

    public string FileName { get; set; }

    public string FileUrl { get; set; }

    public MediaType MediaType { get; set; }

    public string FileType { get; set; }

    public string? ThumbnailUrl { get; set; }

    public bool IsHero { get; set; }

    public int SortOrder { get; set; }

    public bool IsDeleted { get; set; }

    public DateTime CreatedAt { get; set; }
    
}
