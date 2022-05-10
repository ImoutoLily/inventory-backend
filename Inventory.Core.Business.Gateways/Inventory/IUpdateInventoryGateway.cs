namespace Inventory.Core.Business.Gateways.Inventory;

public interface IUpdateInventoryGateway
{
    Task<Models.Inventory?> Update(int id, string newName);
}