using Inventory.Core.Business.Errors;
using Inventory.Core.Business.Gateways.Inventory;
using Inventory.Core.Business.Models;
using Inventory.Core.Business.Validators;

namespace Inventory.Core.Business.Inventory;

public class UpdateInventory
{
    private readonly IUpdateInventoryGateway _updateInventory;

    public UpdateInventory(IUpdateInventoryGateway updateInventory)
    {
        _updateInventory = updateInventory;
    }

    public async Task<Result<Core.Models.Inventory>> Update(int id, Core.Models.Inventory request)
    {
        if (!InventoryValidator.IsNameValid(request.Name))
        {
            return Result.Fail<Core.Models.Inventory>(new InvalidInventoryNameError());
        }
        
        var inventory = await _updateInventory.Update(id, request.Name);

        return inventory is null 
            ? Result.Fail<Core.Models.Inventory>(new EntityWithIdNotExistsError(typeof(Core.Models.Inventory), id)) 
            : Result.Ok(inventory);
    }
}