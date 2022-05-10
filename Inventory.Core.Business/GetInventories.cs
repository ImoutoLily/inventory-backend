using Inventory.Core.Business.Errors;
using Inventory.Core.Business.Gateways;
using Inventory.Core.Business.Models.Core;
using Inventory.Core.Business.Models.Result;

namespace Inventory.Core.Business;

public class GetInventories
{
    private readonly IGetInventoriesGateway _getInventories;

    public GetInventories(IGetInventoriesGateway getInventories)
    {
        _getInventories = getInventories;
    }

    public async Task<Result<GetInventoryByIdResult>> GetById(int id)
    {
        var inventory = await _getInventories.GetById(id);

        if (inventory is null)
        {
            return Result.Fail<GetInventoryByIdResult>(
                new EntityWithIdNotExistsError(typeof(Core.Models.Inventory), id));
        }
        
        return Result.Ok<GetInventoryByIdResult>(new GetInventoryByIdResult(inventory));
    }
    
    public async Task<Result<GetAllInventoriesResult>> GetAll()
    {
        var inventories = await _getInventories.GetAll();

        return Result.Ok(new GetAllInventoriesResult(inventories));
    }
}