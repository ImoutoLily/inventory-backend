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
    private readonly UserManager<InventoryIdentityUser> _userManager;

    public AuthenticateGateway(InventoryContext context, 
        UserManager<InventoryIdentityUser> userManager) : base(context)
    {
        _userManager = userManager;
    }

    public async Task<User?> Login(string username, string password)
    {
        var user = await Context.Users
            .SingleOrDefaultAsync(u => u.UserName == username);

        if (user is null || !await _userManager.CheckPasswordAsync(user, password))
        {
            return null;
        }
        
        return user.Adapt<User>();
    }

    public async Task<User?> Register(string username, string password)
    {
        var storedUser = await Context.Users
            .SingleOrDefaultAsync(u => u.UserName == username);

        if (storedUser is not null) return null;

        var user = new InventoryIdentityUser
        {
            UserName = username
        };

        await _userManager.CreateAsync(user, password);

        return user.Adapt<User>();
    }
}