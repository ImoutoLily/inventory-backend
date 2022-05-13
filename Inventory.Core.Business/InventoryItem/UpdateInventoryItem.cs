using Inventory.Core.Business.Errors;
using Inventory.Core.Business.Gateways.InventoryItem;
using Inventory.Core.Business.Models;
using Inventory.Core.Business.Validators;

namespace Inventory.Core.Business.InventoryItem;

public class UpdateInventoryItem
{
    private readonly IUpdateInventoryItemGateway _updateInventoryItem;

    public UpdateInventoryItem(IUpdateInventoryItemGateway updateInventoryItem)
    {
        _updateInventoryItem = updateInventoryItem;
    }

    public async Task<Result<Core.Models.InventoryItem>> Update(int id, Core.Models.InventoryItem request)
    {
        if (!InventoryItemValidator.IsNameValid(request.Name))
        {
            return Result.Fail<Core.Models.InventoryItem>(new InvalidInventoryItemNamError());
        }

        var inventoryItem = await _updateInventoryItem.Update(id, request.Name, 
            request.Count, request.PricePerItem, request.AdditionalInformation);
        
        return inventoryItem is null
            ? Result.Fail<Core.Models.InventoryItem>(
                new EntityWithIdNotExistsError(typeof(Core.Models.InventoryItem), id))
            : Result.Ok(inventoryItem);
    }
}