using Inventory.Core.Business.Errors;
using Inventory.Core.Business.Gateways.InventoryItem;
using Inventory.Core.Business.Models;
using Inventory.Core.Business.Validators;

namespace Inventory.Core.Business.InventoryItem;

public class CreateInventoryItem
{
    private readonly ICreateInventoryItemGateway _createInventoryItem;

    public CreateInventoryItem(ICreateInventoryItemGateway createInventoryItem)
    {
        _createInventoryItem = createInventoryItem;
    }

    public async Task<Result<Core.Models.InventoryItem>> Create(int inventoryId, Core.Models.InventoryItem request)
    {
        if (!InventoryItemValidator.IsNameValid(request.Name))
            return Result.Fail<Core.Models.InventoryItem>(new InvalidInventoryItemNamError());
        if (!InventoryItemValidator.IsCountValid(request.Count))
            return Result.Fail<Core.Models.InventoryItem>(new InvalidCountError());
        if (!InventoryItemValidator.IsPricePerItemValid(request.PricePerItem))
            return Result.Fail<Core.Models.InventoryItem>(new InvalidPricePerItemError());

        var inventoryItem = await _createInventoryItem.Create(inventoryId, request.Name, request.Count, 
        request.PricePerItem, request.AdditionalInformation);

        if (inventoryItem is null)
        {
            return Result.Fail<Core.Models.InventoryItem>(
                new EntityWithIdNotExistsError(typeof(Core.Models.Inventory), inventoryId));
        }

        return Result.Ok(inventoryItem);
    }
}