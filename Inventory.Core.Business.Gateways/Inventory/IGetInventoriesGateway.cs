namespace Inventory.Core.Business.Gateways.Inventory;

public interface IGetInventoriesGateway
{
    Task<Models.Inventory?> GetById(int id);
    Task<IList<Models.Inventory>> GetAll();
}