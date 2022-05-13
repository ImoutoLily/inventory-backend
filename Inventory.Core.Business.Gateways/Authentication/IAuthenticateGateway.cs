using Inventory.Core.Models;

namespace Inventory.Core.Business.Gateways.Authentication;

public interface IAuthenticateGateway
{
    Task<User?> Login(string? email, string? username, string password);
    Task<User?> Register(string email, string username, string password);
}