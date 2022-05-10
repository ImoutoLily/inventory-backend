using Inventory.Core.Business.Gateways;
using Inventory.Core.Models;
using Inventory.Database.Context;
using Inventory.Gateways.Abstract;
using Microsoft.EntityFrameworkCore;

namespace Inventory.Gateways.DatabaseGateways;

public class UpdateInventoryItemGateway : BaseDatabaseGateway, IUpdateInventoryItemGateway
{
    public UpdateInventoryItemGateway(InventoryContext context) : base(context)
    {
    }

    public async Task<InventoryItem?> Update(int id, string name, int? count, double? pricePerItem, string? additionalInformation)
    {
        var inventoryItem = await Context.InventoryItems
            .SingleOrDefaultAsync(ii => ii.Id == id);

        if (inventoryItem is null) return null;

        inventoryItem.Name = name;
        inventoryItem.Count = count ?? 0;
        inventoryItem.PricePerItem = pricePerItem;
        inventoryItem.AdditionalInformation = additionalInformation;

        await Context.SaveChangesAsync();

        return inventoryItem;
    }
}