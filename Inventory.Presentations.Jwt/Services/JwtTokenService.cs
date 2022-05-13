using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Inventory.Presentations.Jwt.Models;
using Inventory.Presentations.Jwt.Services.Abstract;
using Microsoft.IdentityModel.Tokens;

namespace Inventory.Presentations.Jwt.Services;

public class JwtTokenService : IJwtTokenService
{
    private readonly byte[] _keyBytes;
    private readonly JwtSecurityTokenHandler _tokenHandler;

    public JwtTokenService(JwtSettings settings)
    {
        _keyBytes = Encoding.UTF8.GetBytes(settings.Key);
        _tokenHandler = new JwtSecurityTokenHandler();
    }

    public JwtTokenResult GenerateToken(string username)
    {
        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(new []
            {
                new Claim(ClaimTypes.NameIdentifier, username)
            }),
            Expires = DateTime.Now.AddHours(1),
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(_keyBytes), 
                SecurityAlgorithms.HmacSha256Signature)
        };

        var token = _tokenHandler.CreateToken(tokenDescriptor);

        return new JwtTokenResult
        {
            Token = _tokenHandler.WriteToken(token)
        };
    }
}