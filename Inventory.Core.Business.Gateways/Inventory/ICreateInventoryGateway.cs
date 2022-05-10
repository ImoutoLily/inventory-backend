namespace Inventory.Core.Business.Gateways.Inventory;

public interface ICreateInventoryGateway
{
    Task<Models.Inventory> Save(string name);
}