using System;
using Microsoft.AspNetCore.Identity;
using RealEstateMediaPlatform.API.Models.Enums;

namespace RealEstateMediaPlatform.API.Models;

public class User : IdentityUser<int>
{
    public string FullName { get; set; }

    public UserRole Role { get; set; }  = UserRole.Agent;
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
}
