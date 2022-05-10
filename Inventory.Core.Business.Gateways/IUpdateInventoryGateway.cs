namespace Inventory.Core.Business.Gateways;

public interface IUpdateInventoryGateway
{
    Task<Models.Inventory?> UpdateInventory(int id, string newName);
}