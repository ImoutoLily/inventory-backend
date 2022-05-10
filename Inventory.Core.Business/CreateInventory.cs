using Inventory.Core.Business.Errors;
using Inventory.Core.Business.Gateways;
using Inventory.Core.Business.Models.Core;
using Inventory.Core.Business.Models.Request;
using Inventory.Core.Business.Models.Result;

namespace Inventory.Core.Business;

public class CreateInventory
{
    private readonly ISaveInventoryGateway _saveInventory;

    public CreateInventory(ISaveInventoryGateway saveInventory)
    {
        _saveInventory = saveInventory;
    }

    public async Task<Result<CreateInventoryResult>> Create(CreateInventoryRequest request)
    {
        if (string.IsNullOrWhiteSpace(request.Name))
        {
            return Result.Fail<CreateInventoryResult>(new InvalidInventoryNameError());
        }
        
        var inventory = await _saveInventory.Save(request.Name);

        return Result.Ok(new CreateInventoryResult(inventory));
    }
}