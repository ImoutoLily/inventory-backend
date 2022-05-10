using Inventory.Core.Models;

namespace Inventory.Core.Business.Gateways;

public interface IGetInventoryItemsGateway
{
    Task<InventoryItem?> GetById(int id);
    Task<IList<InventoryItem>?> GetAllByInventoryId(int inventoryId);
}