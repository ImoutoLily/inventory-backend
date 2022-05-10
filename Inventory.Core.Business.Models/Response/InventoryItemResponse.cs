using Inventory.Core.Models;

namespace Inventory.Core.Business.Models.Response;

public class InventoryItemResponse
{
    public InventoryItemResponse(InventoryItem item)
    {
        Item = item;
    }
    public InventoryItem Item { get; }
}