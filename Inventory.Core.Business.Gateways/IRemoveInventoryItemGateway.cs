namespace Inventory.Core.Business.Gateways;

public interface IRemoveInventoryItemGateway
{
    Task<bool> Remove(int id);
}