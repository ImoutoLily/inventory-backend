using Inventory.Core.Business.Errors;
using Inventory.Core.Business.Gateways;
using Inventory.Core.Business.Models.Core;
using Inventory.Core.Business.Models.Result;

namespace Inventory.Core.Business;

public class CreateInventory
{
    private readonly ISaveInventoryGateway _saveInventory;

    public CreateInventory(ISaveInventoryGateway saveInventory)
    {
        _saveInventory = saveInventory;
    }

    public async Task<Result<CreateInventoryResult>> Create(string name)
    {
        if (string.IsNullOrWhiteSpace(name))
        {
            return Result.Fail<CreateInventoryResult>(new InvalidInventoryNameError());
        }
        
        var inventory = await _saveInventory.Save(name);

        return Result.Ok(new CreateInventoryResult(inventory));
    }
}