namespace Inventory.Core.Business.Gateways.InventoryItem;

public interface IRemoveInventoryItemGateway
{
    Task<bool> Remove(int id);
}