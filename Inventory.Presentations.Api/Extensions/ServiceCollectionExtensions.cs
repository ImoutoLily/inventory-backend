using System.Text;
using Inventory.Core.Business.Authentication;
using Inventory.Core.Business.Gateways.Authentication;
using Inventory.Core.Business.Gateways.Inventory;
using Inventory.Core.Business.Gateways.InventoryItem;
using Inventory.Core.Business.Inventory;
using Inventory.Core.Business.InventoryItem;
using Inventory.Database.Context;
using Inventory.Database.Context.Models;
using Inventory.Gateways.DatabaseGateways.Authentication;
using Inventory.Gateways.DatabaseGateways.Inventory;
using Inventory.Gateways.DatabaseGateways.InventoryItem;
using Inventory.Presentations.Api.Helpers;
using Inventory.Presentations.Jwt.Models;
using Inventory.Presentations.Jwt.Services;
using Inventory.Presentations.Jwt.Services.Abstract;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace Inventory.Presentations.Api.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddAppsettings(this IServiceCollection services, 
        IConfiguration configuration)
    {
        var jwtSettings = new JwtSettings();
        
        configuration.GetSection(nameof(JwtSettings))
            .Bind(jwtSettings);

        services.AddSingleton(jwtSettings);
        
        return services;
    }
    
    public static IServiceCollection AddInventoryContext(this IServiceCollection services,
        IWebHostEnvironment environment)
    {
        if (environment.IsDevelopment())
        {
            services.AddDbContext<InventoryContext>(o 
                => o.UseInMemoryDatabase(databaseName: "inventory-inmemory"));
        }
        else
        {
            // TODO: connect to persistent database
        }

        return services;
    }

    public static IServiceCollection AddIdentity(this IServiceCollection services)
    {
        services.AddIdentity<InventoryIdentityUser, IdentityRole>(
            o =>
            {
                o.Password.RequiredLength = 8;
                
                o.User.RequireUniqueEmail = true;
                o.User.AllowedUserNameCharacters = CharacterSet.Lower + CharacterSet.Upper 
                                                                      + CharacterSet.Digits + " -_";
            }
        ).AddEntityFrameworkStores<InventoryContext>();
        
        return services;
    }

    public static IServiceCollection AddGateways(this IServiceCollection services)
    {
        services.AddTransient<IGetInventoriesGateway, GetInventoriesGateway>()
            .AddTransient<ICreateInventoryGateway, CreateInventoryGateway>()
            .AddTransient<IUpdateInventoryGateway, UpdateInventoryGateway>()
            .AddTransient<IRemoveInventoryGateway, RemoveInventoryGateway>()
            .AddTransient<IGetInventoryItemsGateway, GetInventoryItemsGateway>()
            .AddTransient<ICreateInventoryItemGateway, CreateInventoryItemGateway>()
            .AddTransient<IUpdateInventoryItemGateway, UpdateInventoryItemGateway>()
            .AddTransient<IRemoveInventoryItemGateway, RemoveInventoryItemGateway>()
            .AddTransient<IAuthenticateGateway, AuthenticateGateway>();

        return services;
    }

    public static IServiceCollection AddUseCases(this IServiceCollection services)
    {
        services.AddTransient<CreateInventory>()
            .AddTransient<GetInventories>()
            .AddTransient<UpdateInventory>()
            .AddTransient<RemoveInventory>()
            .AddTransient<GetInventoryItems>()
            .AddTransient<CreateInventoryItem>()
            .AddTransient<UpdateInventoryItem>()
            .AddTransient<RemoveInventoryItem>()
            .AddTransient<Authenticate>();

        return services;
    }

    public static IServiceCollection AddJwt(this IServiceCollection services)
    {
        string key; 
        
        using (var builtServices = services.BuildServiceProvider())
        {
            var jwtSettings = builtServices.GetRequiredService<JwtSettings>();
            key = jwtSettings.Key;
        }
        
        services.AddAuthentication(x =>
        {
            x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        }).AddJwtBearer(o =>
        {
            o.SaveToken = true;
        
            o.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = false,
                ValidateAudience = false,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key))
            };
        });

        services.AddSingleton<IJwtTokenService, JwtTokenService>();

        return services;
    }
}