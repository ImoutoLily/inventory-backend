namespace Inventory.Core.Business.Gateways.InventoryItem;

public interface ICreateInventoryItemGateway
{
    Task<Models.InventoryItem?> Create(int inventoryId, string name, int? count = null, 
        double? pricePerItem = null, string? additionalInformation = null);
}