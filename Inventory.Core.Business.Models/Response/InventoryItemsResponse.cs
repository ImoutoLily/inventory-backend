using Inventory.Core.Models;

namespace Inventory.Core.Business.Models.Response;

public class InventoryItemsResponse
{
    public InventoryItemsResponse(IList<InventoryItem> inventoryItems)
    {
        InventoryItems = inventoryItems;
    }

    public IList<InventoryItem> InventoryItems { get; }
}