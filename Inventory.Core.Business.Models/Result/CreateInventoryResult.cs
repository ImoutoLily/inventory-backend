namespace Inventory.Core.Business.Models.Result;

public class CreateInventoryResult
{
    public CreateInventoryResult(Inventory.Core.Models.Inventory inventory)
    {
        Inventory = inventory;
    }

    public Inventory.Core.Models.Inventory Inventory { get; }
}