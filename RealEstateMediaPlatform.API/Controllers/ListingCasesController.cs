using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using RealEstateMediaPlatform.API.DTOs;
using RealEstateMediaPlatform.API.Services;

namespace RealEstateMediaPlatform.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ListingCasesController : ControllerBase
{
    private readonly ListingCaseService _service;

    public ListingCasesController(ListingCaseService service)
    {
        _service = service;
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateListingCaseDto dto)
    {
        var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

        if (string.IsNullOrEmpty(userId))
            return Unauthorized();

        var listingId = await _service.CreateAsync(dto, userId);

        return CreatedAtAction(
            nameof(GetById),
            new { id = listingId },
            new { id = listingId }
        );
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var result = await _service.GetByIdAsync(id);

        if (result == null)
            return NotFound();

        return Ok(result);
    }
}