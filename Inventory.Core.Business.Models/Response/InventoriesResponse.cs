namespace Inventory.Core.Business.Models.Response;

public class InventoriesResponse
{
    public InventoriesResponse(IList<Inventory.Core.Models.Inventory> inventories)
    {
        Inventories = inventories;
    }

    public IList<Inventory.Core.Models.Inventory> Inventories { get; }
}