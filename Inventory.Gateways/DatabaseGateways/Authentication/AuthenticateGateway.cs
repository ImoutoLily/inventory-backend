using Inventory.Core.Business.Gateways.Authentication;
using Inventory.Core.Models;
using Inventory.Database.Context;
using Inventory.Database.Context.Models;
using Inventory.Gateways.Abstract;
using Mapster;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Inventory.Gateways.DatabaseGateways.Authentication;

public class AuthenticateGateway : BaseDatabaseGateway, IAuthenticateGateway
{
    private readonly UserManager<DatabaseUser> _userManager;

    public AuthenticateGateway(InventoryContext context, 
        UserManager<DatabaseUser> userManager) : base(context)
    {
        _userManager = userManager;
    }

    public async Task<User?> Login(string? email, string? username, string password)
    {
        var user = await GetUserByEmailOrUsername(email, username);
        
        if (user is null || !await _userManager.CheckPasswordAsync(user, password))
        {
            return null;
        }
        
        return user.Adapt<User>();
    }

    public async Task<User?> Register(string email, string username, string password)
    {
        var storedUser = await Context.Users
            .SingleOrDefaultAsync(u => u.UserName == username);

        if (storedUser is not null) return null;

        var user = new DatabaseUser
        {
            Email = email,
            UserName = username
        };

        await _userManager.CreateAsync(user, password);

        return user.Adapt<User>();
    }

    private async Task<DatabaseUser?> GetUserByEmailOrUsername(string? email, string? username)
    {
        if (email is not null)
        {
            return await Context.Users
                .SingleOrDefaultAsync(u => u.Email == email);
        }

        if (username is not null)
        {
            return await Context.Users
                .SingleOrDefaultAsync(u => u.UserName == username);
        }

        throw new InvalidOperationException();
    }
}