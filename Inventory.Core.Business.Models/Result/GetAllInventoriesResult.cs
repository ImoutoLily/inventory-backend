namespace Inventory.Core.Business.Models.Result;

public class GetAllInventoriesResult
{
    public GetAllInventoriesResult(IList<Inventory.Core.Models.Inventory> inventories)
    {
        Inventories = inventories;
    }

    public IList<Inventory.Core.Models.Inventory> Inventories { get; }
}