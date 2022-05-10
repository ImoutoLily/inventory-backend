namespace Inventory.Core.Business.Gateways;

public interface IUpdateInventoryGateway
{
    Task<Models.Inventory?> Update(int id, string newName);
}