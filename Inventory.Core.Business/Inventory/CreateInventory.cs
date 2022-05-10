using Inventory.Core.Business.Errors;
using Inventory.Core.Business.Gateways;
using Inventory.Core.Business.Gateways.Inventory;
using Inventory.Core.Business.Models.Core;
using Inventory.Core.Business.Models.Request;
using Inventory.Core.Business.Models.Response;
using Inventory.Core.Business.Validators;

namespace Inventory.Core.Business.Inventory;

public class CreateInventory
{
    private readonly ICreateInventoryGateway _createInventory;

    public CreateInventory(ICreateInventoryGateway createInventory)
    {
        _createInventory = createInventory;
    }

    public async Task<Result<InventoryResponse>> Create(InventoryRequest request)
    {
        if (!InventoryValidator.IsNameValid(request.Name))
        {
            return Result.Fail<InventoryResponse>(new InvalidInventoryNameError());
        }
        
        var inventory = await _createInventory.Save(request.Name);

        return Result.Ok(new InventoryResponse(inventory));
    }
}