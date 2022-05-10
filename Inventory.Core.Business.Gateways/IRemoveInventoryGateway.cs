namespace Inventory.Core.Business.Gateways;

public interface IRemoveInventoryGateway
{
    Task<bool> Remove(int id);
}