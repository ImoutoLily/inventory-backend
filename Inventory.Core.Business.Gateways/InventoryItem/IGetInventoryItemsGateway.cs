namespace Inventory.Core.Business.Gateways.InventoryItem;

public interface IGetInventoryItemsGateway
{
    Task<Models.InventoryItem?> GetById(int id);
    Task<IList<Models.InventoryItem>?> GetAllByInventoryId(int inventoryId);
}