using Inventory.Core.Business.Errors;
using Inventory.Core.Business.Gateways;
using Inventory.Core.Business.Gateways.InventoryItem;
using Inventory.Core.Business.Models.Core;
using Inventory.Core.Business.Models.Response;

namespace Inventory.Core.Business.InventoryItem;

public class GetInventoryItems
{
    private readonly IGetInventoryItemsGateway _getInventoryItems;

    public GetInventoryItems(IGetInventoryItemsGateway getInventoryItems)
    {
        _getInventoryItems = getInventoryItems;
    }

    public async Task<Result<InventoryItemResponse>> GetById(int id)
    {
        var inventoryItem = await _getInventoryItems.GetById(id);

        if (inventoryItem is null)
        {
            return Result.Fail<InventoryItemResponse>(
                new EntityWithIdNotExistsError(typeof(Core.Models.InventoryItem), id));
        }
        
        return Result.Ok(new InventoryItemResponse(inventoryItem));
    }

    public async Task<Result<InventoryItemsResponse>> GetAllByInventoryId(int inventoryId)
    {
        var inventoryItems = await _getInventoryItems.GetAllByInventoryId(inventoryId);

        if (inventoryItems is null)
        {
            return Result.Fail<InventoryItemsResponse>(
                new EntityWithIdNotExistsError(typeof(Core.Models.Inventory), inventoryId));
        }
        
        return Result.Ok(new InventoryItemsResponse(inventoryItems));
    }
}