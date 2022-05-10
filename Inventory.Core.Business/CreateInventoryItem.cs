using Inventory.Core.Business.Errors;
using Inventory.Core.Business.Gateways;
using Inventory.Core.Business.Models.Core;
using Inventory.Core.Business.Models.Request;
using Inventory.Core.Business.Models.Response;
using Inventory.Core.Business.Validators;

namespace Inventory.Core.Business;

public class CreateInventoryItem
{
    private readonly ICreateInventoryItemGateway _createInventoryItem;

    public CreateInventoryItem(ICreateInventoryItemGateway createInventoryItem)
    {
        _createInventoryItem = createInventoryItem;
    }

    public async Task<Result<InventoryItemResponse>> Create(int inventoryId, InventoryItemRequest request)
    {
        if (!InventoryItemValidator.IsNameValid(request.Name))
        {
            return Result.Fail<InventoryItemResponse>(new InvalidInventoryItemNamError());
        }

        var inventoryItem = await _createInventoryItem.Create(inventoryId, request.Name, request.Count, 
            request.PricePerItem, request.AdditionalInformation);

        if (inventoryItem is null)
        {
            return Result.Fail<InventoryItemResponse>(
                new EntityWithIdNotExistsError(typeof(Core.Models.Inventory), inventoryId));
        }

        return Result.Ok(new InventoryItemResponse(inventoryItem));
    }
}