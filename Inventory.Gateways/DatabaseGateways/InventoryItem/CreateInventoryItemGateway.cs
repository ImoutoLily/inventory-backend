using Inventory.Core.Business.Gateways.InventoryItem;
using Inventory.Database.Context;
using Inventory.Gateways.Abstract;
using Microsoft.EntityFrameworkCore;

namespace Inventory.Gateways.DatabaseGateways.InventoryItem;

public class CreateInventoryItemGateway : BaseDatabaseGateway, ICreateInventoryItemGateway
{
    public CreateInventoryItemGateway(InventoryContext context) : base(context)
    {
    }

    public async Task<Core.Models.InventoryItem?> Create(int inventoryId, string name, 
        int? count = null, double? pricePerItem = null, string? additionalInformation = null)
    {
        var inventory = await Context.Inventories
            .SingleOrDefaultAsync(i => i.Id == inventoryId);

        if (inventory is null) return null;

        var inventoryItem = new Core.Models.InventoryItem
        {
            Name = name,
            Count = count ?? 0,
            PricePerItem = pricePerItem,
            AdditionalInformation = additionalInformation
        };

        inventory.Items.Add(inventoryItem);

        await Context.SaveChangesAsync();

        return inventoryItem;
    }
}