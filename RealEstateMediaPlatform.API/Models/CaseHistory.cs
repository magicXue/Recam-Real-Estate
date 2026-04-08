using System;
using RealEstateMediaPlatform.API.Models.Enums;

namespace RealEstateMediaPlatform.API.Models;

public class CaseHistory
{
    public int Id { get; set; }
    public int ListingCaseId { get; set; }
    public ListingCase ListingCase { get; set; }
    public int ChangedByUserId { get; set; }
    public User ChangedByUser { get; set; }
    public ListingStatus OldStatus { get; set; }
    public ListingStatus NewStatus { get; set; }
    public DateTime ChangedAt { get; set; }
}
