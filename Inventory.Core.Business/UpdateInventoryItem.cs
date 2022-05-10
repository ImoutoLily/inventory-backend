using Inventory.Core.Business.Errors;
using Inventory.Core.Business.Gateways;
using Inventory.Core.Business.Models.Core;
using Inventory.Core.Business.Models.Request;
using Inventory.Core.Business.Models.Response;
using Inventory.Core.Business.Validators;
using Inventory.Core.Models;

namespace Inventory.Core.Business;

public class UpdateInventoryItem
{
    private readonly IUpdateInventoryItemGateway _updateInventoryItem;

    public UpdateInventoryItem(IUpdateInventoryItemGateway updateInventoryItem)
    {
        _updateInventoryItem = updateInventoryItem;
    }

    public async Task<Result<InventoryItemResponse>> Update(int id, InventoryItemRequest request)
    {
        if (!InventoryItemValidator.IsNameValid(request.Name))
        {
            return Result.Fail<InventoryItemResponse>(new InvalidInventoryItemNamError());
        }

        var inventoryItem = await _updateInventoryItem.Update(id, request.Name, 
            request.Count, request.PricePerItem, request.AdditionalInformation);
        
        return inventoryItem is null
            ? Result.Fail<InventoryItemResponse>(new EntityWithIdNotExistsError(typeof(InventoryItem), id))
            : Result.Ok(new InventoryItemResponse(inventoryItem));
    }
}