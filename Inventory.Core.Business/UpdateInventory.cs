using Inventory.Core.Business.Errors;
using Inventory.Core.Business.Gateways;
using Inventory.Core.Business.Models.Core;
using Inventory.Core.Business.Models.Request;
using Inventory.Core.Business.Models.Result;
using Inventory.Core.Business.Validators;

namespace Inventory.Core.Business;

public class UpdateInventory
{
    private readonly IUpdateInventoryGateway _updateInventory;

    public UpdateInventory(IUpdateInventoryGateway updateInventory)
    {
        _updateInventory = updateInventory;
    }

    public async Task<Result<InventoryResult>> Update(int id, InventoryRequest request)
    {
        if (!InventoryValidator.IsNameValid(request.Name))
        {
            return Result.Fail<InventoryResult>(new InvalidInventoryNameError());
        }
        
        var inventory = await _updateInventory.UpdateInventory(id, request.Name);

        return inventory is null 
            ? Result.Fail<InventoryResult>(new EntityWithIdNotExistsError(typeof(Core.Models.Inventory), id)) 
            : Result.Ok<InventoryResult>(new InventoryResult(inventory));
    }
}