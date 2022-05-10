using Inventory.Core.Business.Gateways;
using Inventory.Database.Context;
using Inventory.Gateways.Abstract;
using Microsoft.EntityFrameworkCore;

namespace Inventory.Gateways.DatabaseGateways;

public class RemoveInventoryGateway : BaseDatabaseGateway, IRemoveInventoryGateway
{
    public RemoveInventoryGateway(InventoryContext context) : base(context)
    {
    }

    public async Task<bool> Remove(int id)
    {
        var inventory = await Context.Inventories
            .SingleOrDefaultAsync(i => i.Id == id);

        if (inventory is null) return false;

        Context.Remove(inventory);

        await Context.SaveChangesAsync();

        return true;
    }
}