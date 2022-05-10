using Inventory.Core.Business.Gateways;
using Inventory.Core.Models;
using Inventory.Database.Context;
using Inventory.Gateways.Abstract;
using Microsoft.EntityFrameworkCore;

namespace Inventory.Gateways.DatabaseGateways;

public class GetInventoryItemsGateway : BaseDatabaseGateway, IGetInventoryItemsGateway
{
    public GetInventoryItemsGateway(InventoryContext context) : base(context)
    {
    }

    public async Task<InventoryItem?> GetById(int id)
    {
        var inventoryItem = await Context.InventoryItems
            .SingleOrDefaultAsync(ii => ii.Id == id);

        return inventoryItem;
    }

    public async Task<IList<InventoryItem>?> GetAllByInventoryId(int inventoryId)
    {
        var inventory = await Context.Inventories
            .Include(i => i.Items)
            .SingleOrDefaultAsync(i => i.Id == inventoryId);

        return inventory?.Items;
    }
}