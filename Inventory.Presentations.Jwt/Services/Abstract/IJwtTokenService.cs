using Inventory.Presentations.Jwt.Models;

namespace Inventory.Presentations.Jwt.Services.Abstract;

public interface IJwtTokenService
{
    JwtTokenResult GenerateToken(string username);
}