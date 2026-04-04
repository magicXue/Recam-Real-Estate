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

    // 🔐 创建 Listing（需要登录）
    [HttpPost]
    [Authorize]
    public async Task<IActionResult> Create(CreateListingCaseDto dto)
    {
        var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

        await _service.CreateAsync(dto, userId);

        return Ok();
    }
}