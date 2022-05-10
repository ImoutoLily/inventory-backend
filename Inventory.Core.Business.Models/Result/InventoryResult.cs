namespace Inventory.Core.Business.Models.Result;

public class InventoryResult
{
    public InventoryResult(Inventory.Core.Models.Inventory inventory)
    {
        Inventory = inventory;
    }

    public Inventory.Core.Models.Inventory Inventory { get; }
}