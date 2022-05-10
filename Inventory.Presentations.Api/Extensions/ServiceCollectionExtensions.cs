using Inventory.Core.Business;
using Inventory.Core.Business.Gateways;
using Inventory.Core.Business.Gateways.Inventory;
using Inventory.Core.Business.Gateways.InventoryItem;
using Inventory.Core.Business.Inventory;
using Inventory.Core.Business.InventoryItem;
using Inventory.Database.Context;
using Inventory.Gateways;
using Inventory.Gateways.DatabaseGateways;
using Inventory.Gateways.DatabaseGateways.Inventory;
using Inventory.Gateways.DatabaseGateways.InventoryItem;
using Microsoft.EntityFrameworkCore;

namespace Inventory.Presentations.Api.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddInventoryContext(this IServiceCollection services,
        IWebHostEnvironment environment)
    {
        if (environment.IsDevelopment())
        {
            services.AddDbContext<InventoryContext>(o 
                => o.UseInMemoryDatabase(databaseName: "inventory-db"));
        }
        else
        {
            // TODO: connect to persistent database
        }

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
            .AddTransient<IRemoveInventoryItemGateway, RemoveInventoryItemGateway>();

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
            .AddTransient<RemoveInventoryItem>();

        return services;
    }
}