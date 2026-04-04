using System.ComponentModel.DataAnnotations;
namespace RealEstateMediaPlatform.API.DTOs;
public class CreateListingCaseDto
{
    [Required]
    [MaxLength(255)]
    public string Title { get; set; } = default!;

    [Required]
    [MaxLength(500)]
    public string Address { get; set; } = default!;

    [Range(0, int.MaxValue)]
    public int Bedrooms { get; set; }

    [Range(0, double.MaxValue)]
    public decimal? Price { get; set; }
}