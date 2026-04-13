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
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var userId = User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value;

        var result = await _service.GetAllAsync(userId!);

        return Ok(result);
    }
    [HttpPut("{id}")]
    [Authorize]
    public async Task<IActionResult> Update(int id, [FromBody] UpdateListingCaseDto dto)
    {
        var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

        if (string.IsNullOrEmpty(userId))
            return Unauthorized();

        var success = await _service.UpdateAsync(id, dto, userId);

        if (!success)
            return NotFound();

        return NoContent();
    }
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

        if (string.IsNullOrEmpty(userId))
            return Unauthorized();

        var success = await _service.DeleteAsync(id, userId);

        if (!success)
            return NotFound();

        return NoContent();
    }
    [HttpPatch("{id}/property-status")]
    public async Task<IActionResult> UpdatePropertyStatus(int id, [FromBody] UpdatePropertyStatusDto dto)
    {
        var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

        if (string.IsNullOrEmpty(userId))
            return Unauthorized();

        var success = await _service.UpdatePropertyStatusAsync(id, dto.PropertyStatus, userId);

        if (!success)
            return NotFound();

        return NoContent();
    }
}