using Inventory.Core.Business.Errors;
using Inventory.Core.Business.Gateways;
using Inventory.Core.Business.Models.Core;
using Inventory.Core.Models;

namespace Inventory.Core.Business;

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
            ? Result.Fail<bool>(new EntityWithIdNotExistsError(typeof(InventoryItem), id))
            : Result.Ok(true);
    }
}