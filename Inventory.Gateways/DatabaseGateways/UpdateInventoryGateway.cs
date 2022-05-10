using Inventory.Core.Business.Gateways;
using Inventory.Database.Context;
using Inventory.Gateways.Abstract;
using Microsoft.EntityFrameworkCore;

namespace Inventory.Gateways.DatabaseGateways;

public class UpdateInventoryGateway : BaseDatabaseGateway, IUpdateInventoryGateway
{
    public UpdateInventoryGateway(InventoryContext context) : base(context)
    {
    }

    public async Task<Core.Models.Inventory?> UpdateInventory(int id, string newName)
    {
        var inventory = await Context.Inventories
            .SingleOrDefaultAsync(i => i.Id == id);

        if (inventory is null) return null;

        inventory.Name = newName;

        await Context.SaveChangesAsync();

        return inventory;
    }
}