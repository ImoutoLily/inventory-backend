using Inventory.Core.Business.Authentication;
using Inventory.Core.Business.Models.Request;
using Inventory.Presentations.Api.Controllers.Abstract;
using Inventory.Presentations.Jwt.Services.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace Inventory.Presentations.Api.Controllers;

public class AuthenticationController : BaseController
{
    private readonly IJwtTokenService _tokenService;

    private readonly Authenticate _authenticate;

    public AuthenticationController(IJwtTokenService tokenService, Authenticate authenticate)
    {
        _tokenService = tokenService;
        _authenticate = authenticate;
    }

    [HttpPost("Login")]
    public async Task<IActionResult> Login(AuthenticationRequest request)
    {
        var result = await _authenticate.Login(request);

        if (result.Error is not null)
        {
            return Ok(result);
        }

        var token = _tokenService.GenerateToken(result.Value!.Username);

        return Ok(token);
    }

    [HttpPost("Register")]
    public async Task<IActionResult> Register(AuthenticationRequest request)
    {
        var result = await _authenticate.Register(request);

        if (result.Error is not null)
        {
            return Ok(result);
        }

        var token = _tokenService.GenerateToken(result.Value!.Username);

        return Ok(token);
    }
}