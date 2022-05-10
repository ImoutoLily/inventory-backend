using Inventory.Core.Business.Errors;
using Inventory.Core.Business.Gateways;
using Inventory.Core.Business.Models.Core;
using Inventory.Core.Business.Models.Response;

namespace Inventory.Core.Business;

public class GetInventories
{
    private readonly IGetInventoriesGateway _getInventories;

    public GetInventories(IGetInventoriesGateway getInventories)
    {
        _getInventories = getInventories;
    }

    public async Task<Result<InventoryResult>> GetById(int id)
    {
        var inventory = await _getInventories.GetById(id);

        if (inventory is null)
        {
            return Result.Fail<InventoryResult>(
                new EntityWithIdNotExistsError(typeof(Core.Models.Inventory), id));
        }
        
        return Result.Ok(new InventoryResult(inventory));
    }
    
    public async Task<Result<InventoriesResult>> GetAll()
    {
        var inventories = await _getInventories.GetAll();

        return Result.Ok(new InventoriesResult(inventories));
    }
}