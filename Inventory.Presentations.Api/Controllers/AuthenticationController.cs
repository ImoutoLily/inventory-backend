using Inventory.Core.Business.Authentication;
using Inventory.Core.Models;
using Inventory.Presentations.Api.Controllers.Abstract;
using Inventory.Presentations.Jwt.Services.Abstract;
using Microsoft.AspNetCore.Authorization;
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
    [AllowAnonymous]
    public async Task<IActionResult> Login(AuthenticateRequest request)
    {
        var result = await _authenticate.Login(request);

        if (result.Error is not null)
        {
            return Ok(result);
        }

        var tokenResult = _tokenService.GenerateToken(result.Value!);

        return Ok(tokenResult);
    }

    [HttpPost("Register")]
    [AllowAnonymous]
    public async Task<IActionResult> Register(AuthenticateRequest request)
    {
        var result = await _authenticate.Register(request);

        if (result.Error is not null)
        {
            return Ok(result);
        }

        var tokenResult = _tokenService.GenerateToken(result.Value!);

        return Ok(tokenResult);
    }
}