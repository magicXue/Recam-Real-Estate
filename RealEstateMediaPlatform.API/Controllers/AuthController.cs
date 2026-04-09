using System;
using Microsoft.AspNetCore.Mvc;
using RealEstateMediaPlatform.API.DTOs;

namespace RealEstateMediaPlatform.API.Controllers;
[ApiController]
[Route("api/auth")]
public class AuthController : ControllerBase
{
    private readonly AuthService _service;

    public AuthController(AuthService service)
    {
        _service = service;
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register(RegisterDto dto)
    {
        var token = await _service.RegisterAsync(dto);
        return Ok(new { token });
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login(LoginDto dto)
    {
        var token = await _service.LoginAsync(dto);
        return Ok(new { token });
    }
}
