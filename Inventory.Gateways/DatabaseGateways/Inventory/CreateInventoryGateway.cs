using Inventory.Core.Business.Gateways.Inventory;
using Inventory.Database.Context;
using Inventory.Gateways.Abstract;
using Microsoft.EntityFrameworkCore;

namespace Inventory.Gateways.DatabaseGateways.Inventory;

public class CreateInventoryGateway : BaseDatabaseGateway, ICreateInventoryGateway
{
    public CreateInventoryGateway(InventoryContext context) : base(context)
    {
    }

    public async Task<Core.Models.Inventory> Save(string creatorId, string name)
    {
        var user = await Context.Users
            .SingleAsync(u => u.Id == creatorId);
        
        var inventory = new Core.Models.Inventory
        {
            Name = name
        };

        user.Inventories.Add(inventory);

        await Context.SaveChangesAsync();

        return inventory;
    }
}