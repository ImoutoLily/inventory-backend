using Inventory.Core.Models;

namespace Inventory.Core.Business.Gateways;

public interface ICreateInventoryItemGateway
{
    Task<InventoryItem?> Create(int inventoryId, string name, int? count = null, 
        double? pricePerItem = null, string? additionalInformation = null);
}