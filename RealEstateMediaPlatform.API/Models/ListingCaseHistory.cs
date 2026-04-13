using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace RealEstateMediaPlatform.API.Models;

public class ListingCaseHistory
{
    [BsonId]
    public ObjectId Id { get; set; }

    public int ListingCaseId { get; set; }

    public string Action { get; set; }

    public string? PerformedBy { get; set; }

    public DateTime Timestamp { get; set; }

    public string? DataSnapshot { get; set; }
    public DateTime CreatedAt { get; internal set; }
}