using Inventory.Core.Business.Gateways;
using Inventory.Database.Context;
using Inventory.Gateways.Abstract;
using Microsoft.EntityFrameworkCore;

namespace Inventory.Gateways.DatabaseGateways;

public class RemoveInventoryItemGateway : BaseDatabaseGateway, IRemoveInventoryItemGateway
{
    public RemoveInventoryItemGateway(InventoryContext context) : base(context)
    {
    }

    public async Task<bool> Remove(int id)
    {
        var inventoryItem = await Context.InventoryItems
            .SingleOrDefaultAsync(ii => ii.Id == id);

        if (inventoryItem is null) return false;

        Context.Remove(inventoryItem);

        await Context.SaveChangesAsync();

        return true;
    }
}