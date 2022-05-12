namespace Inventory.Presentations.Jwt.Services.Abstract;

public interface IJwtTokenService
{
    string GenerateToken(string username);
}