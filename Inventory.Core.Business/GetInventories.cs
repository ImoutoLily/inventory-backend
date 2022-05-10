using Inventory.Core.Business.Gateways;
using Inventory.Core.Business.Models.Core;
using Inventory.Core.Business.Models.Result;

namespace Inventory.Core.Business;

public class GetInventories
{
    private readonly IGetInventoriesGateway _getInventories;

    public GetInventories(IGetInventoriesGateway getInventories)
    {
        _getInventories = getInventories;
    }

    public async Task<Result<GetInventoriesResult>> GetAll()
    {
        var inventories = await _getInventories.GetAll();

        return Result.Ok(new GetInventoriesResult(inventories));
    }
}