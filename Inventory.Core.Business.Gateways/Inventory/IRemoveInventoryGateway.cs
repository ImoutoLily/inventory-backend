namespace Inventory.Core.Business.Gateways.Inventory;

public interface IRemoveInventoryGateway
{
    Task<bool> Remove(int id);
}