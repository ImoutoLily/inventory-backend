using Inventory.Core.Models;

namespace Inventory.Core.Business.Models.Response;

public class InventoryItemResponse
{
    public InventoryItemResponse(int inventoryId, InventoryItem item)
    {
        InventoryId = inventoryId;
        Item = item;
    }

    public int InventoryId { get; }
    public InventoryItem Item { get; }
}