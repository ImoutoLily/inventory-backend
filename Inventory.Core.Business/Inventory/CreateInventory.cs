using Inventory.Core.Business.Errors;
using Inventory.Core.Business.Gateways.Inventory;
using Inventory.Core.Business.Models;
using Inventory.Core.Business.Validators;

namespace Inventory.Core.Business.Inventory;

public class CreateInventory
{
    private readonly ICreateInventoryGateway _createInventory;

    public CreateInventory(ICreateInventoryGateway createInventory)
    {
        _createInventory = createInventory;
    }

    public async Task<Result<Core.Models.Inventory>> Create(Core.Models.Inventory request)
    {
        if (!InventoryValidator.IsNameValid(request.Name))
        {
            return Result.Fail<Core.Models.Inventory>(new InvalidInventoryNameError());
        }
        
        var inventory = await _createInventory.Save(request.Name);

        return Result.Ok(inventory);
    }
}