namespace Inventory.Core.Business.Gateways;

public interface ISaveInventoryGateway
{
    Task<Models.Inventory> Save(string name);
}