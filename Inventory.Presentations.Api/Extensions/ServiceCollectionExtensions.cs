using Inventory.Core.Business;
using Inventory.Core.Business.Gateways;
using Inventory.Database.Context;
using Inventory.Gateways;
using Inventory.Gateways.DatabaseGateways;
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
            .AddTransient<ISaveInventoryGateway, SaveInventoryGateway>()
            .AddTransient<IUpdateInventoryGateway, UpdateInventoryGateway>();

        return services;
    }

    public static IServiceCollection AddUseCases(this IServiceCollection services)
    {
        services.AddTransient<CreateInventory>()
            .AddTransient<GetInventories>()
            .AddTransient<UpdateInventory>();

        return services;
    }
}