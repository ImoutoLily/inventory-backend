namespace Inventory.Core.Business.Gateways;

public interface IGetInventoriesGateway
{
    IList<Models.Inventory> GetAll();
}