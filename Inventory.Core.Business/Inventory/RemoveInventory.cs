using Inventory.Core.Business.Errors;
using Inventory.Core.Business.Gateways.Inventory;
using Inventory.Core.Business.Models;

namespace Inventory.Core.Business.Inventory;

public class RemoveInventory
{
    private readonly IRemoveInventoryGateway _removeInventory;

    public RemoveInventory(IRemoveInventoryGateway removeInventory)
    {
        _removeInventory = removeInventory;
    }

    public async Task<Result<bool>> Remove(int id)
    {
        var success = await _removeInventory.Remove(id);

        return !success 
            ? Result.Fail<bool>(new EntityWithIdNotExistsError(typeof(Core.Models.Inventory), id)) 
            : Result.Ok(true);
    }
}