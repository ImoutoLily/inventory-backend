using Inventory.Core.Business.Gateways;
using Inventory.Core.Models;
using Inventory.Database.Context;
using Inventory.Gateways.Abstract;
using Microsoft.EntityFrameworkCore;

namespace Inventory.Gateways.DatabaseGateways;

public class CreateInventoryItemGateway : BaseDatabaseGateway, ICreateInventoryItemGateway
{
    public CreateInventoryItemGateway(InventoryContext context) : base(context)
    {
    }

    public async Task<InventoryItem?> Create(int inventoryId, string name, 
        int? count = null, double? pricePerItem = null, string? additionalInformation = null)
    {
        var inventory = await Context.Inventories
            .SingleOrDefaultAsync(i => i.Id == inventoryId);

        if (inventory is null) return null;

        var inventoryItem = new InventoryItem
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