namespace Inventory.Core.Business.Models.Response;

public class InventoriesResult
{
    public InventoriesResult(IList<Inventory.Core.Models.Inventory> inventories)
    {
        Inventories = inventories;
    }

    public IList<Inventory.Core.Models.Inventory> Inventories { get; }
}