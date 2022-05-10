using Inventory.Core.Business.Errors;
using Inventory.Core.Business.Gateways;
using Inventory.Core.Business.Models.Core;
using Inventory.Core.Business.Models.Request;
using Inventory.Core.Business.Models.Response;
using Inventory.Core.Business.Validators;

namespace Inventory.Core.Business;

public class CreateInventory
{
    private readonly ISaveInventoryGateway _saveInventory;

    public CreateInventory(ISaveInventoryGateway saveInventory)
    {
        _saveInventory = saveInventory;
    }

    public async Task<Result<InventoryResult>> Create(InventoryRequest request)
    {
        if (!InventoryValidator.IsNameValid(request.Name))
        {
            return Result.Fail<InventoryResult>(new InvalidInventoryNameError());
        }
        
        var inventory = await _saveInventory.Save(request.Name);

        return Result.Ok(new InventoryResult(inventory));
    }
}