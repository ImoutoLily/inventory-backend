namespace Inventory.Core.Business.Gateways;

public interface IGetInventoriesGateway
{
    Task<IList<Models.Inventory>> GetAll();
}