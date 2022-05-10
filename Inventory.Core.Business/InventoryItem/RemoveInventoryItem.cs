using Inventory.Core.Business.Errors;
using Inventory.Core.Business.Gateways;
using Inventory.Core.Business.Gateways.InventoryItem;
using Inventory.Core.Business.Models.Core;

namespace Inventory.Core.Business.InventoryItem;

public class RemoveInventoryItem
{
    private readonly IRemoveInventoryItemGateway _removeInventoryItem;

    public RemoveInventoryItem(IRemoveInventoryItemGateway removeInventoryItem)
    {
        _removeInventoryItem = removeInventoryItem;
    }

    public async Task<Result<bool>> Remove(int id)
    {
        var success = await _removeInventoryItem.Remove(id);

        return !success
            ? Result.Fail<bool>(new EntityWithIdNotExistsError(typeof(Core.Models.InventoryItem), id))
            : Result.Ok(true);
    }
}