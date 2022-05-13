using Inventory.Core.Business.Errors;
using Inventory.Core.Business.Gateways.InventoryItem;
using Inventory.Core.Business.Models;

namespace Inventory.Core.Business.InventoryItem;

public class GetInventoryItems
{
    private readonly IGetInventoryItemsGateway _getInventoryItems;

    public GetInventoryItems(IGetInventoryItemsGateway getInventoryItems)
    {
        _getInventoryItems = getInventoryItems;
    }

    public async Task<Result<Core.Models.InventoryItem>> GetById(int id)
    {
        var inventoryItem = await _getInventoryItems.GetById(id);

        if (inventoryItem is null)
        {
            return Result.Fail<Core.Models.InventoryItem>(
                new EntityWithIdNotExistsError(typeof(Core.Models.InventoryItem), id));
        }
        
        return Result.Ok(inventoryItem);
    }

    public async Task<Result<IList<Core.Models.InventoryItem>>> GetAllByInventoryId(int inventoryId)
    {
        var inventoryItems = await _getInventoryItems.GetAllByInventoryId(inventoryId);

        if (inventoryItems is null)
        {
            return Result.Fail<IList<Core.Models.InventoryItem>>(
                new EntityWithIdNotExistsError(typeof(Core.Models.Inventory), inventoryId));
        }
        
        return Result.Ok(inventoryItems);
    }
}