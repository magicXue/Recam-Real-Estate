using System;

namespace RealEstateMediaPlatform.API.Models;

public class UserActivityLog
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public User User { get; set; }
    public string Action { get; set; }
    public DateTime Timestamp { get; set; }

}
