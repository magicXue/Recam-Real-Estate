using System;
using System.ComponentModel.DataAnnotations;
using RealEstateMediaPlatform.API.Models;

namespace RealEstateMediaPlatform.API.DTOs;

public class UpdatePropertyStatusDto
{
    [Required]
    public PropertyStatus PropertyStatus { get; set; }
}
