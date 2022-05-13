using Inventory.Core.Business.Errors;
using Inventory.Core.Business.Gateways.Inventory;
using Inventory.Core.Business.Models;

namespace Inventory.Core.Business.Inventory;

public class GetInventories
{
    private readonly IGetInventoriesGateway _getInventories;

    public GetInventories(IGetInventoriesGateway getInventories)
    {
        _getInventories = getInventories;
    }

    public async Task<Result<Core.Models.Inventory>> GetById(int id)
    {
        var inventory = await _getInventories.GetById(id);

        if (inventory is null)
        {
            return Result.Fail<Core.Models.Inventory>(
                new EntityWithIdNotExistsError(typeof(Core.Models.Inventory), id));
        }
        
        return Result.Ok(inventory);
    }
    
    public async Task<Result<IList<Core.Models.Inventory>>> GetAll()
    {
        var inventories = await _getInventories.GetAll();

        return Result.Ok(inventories);
    }
}