namespace Inventory.Core.Business.Models.Request;

public class AuthenticationRequest
{
    public string Email { get; set; } = null!;
    public string Username { get; set; } = null!;
    public string Password { get; set; } = null!;
}