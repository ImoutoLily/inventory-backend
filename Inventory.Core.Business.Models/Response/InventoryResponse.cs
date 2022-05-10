namespace Inventory.Core.Business.Models.Response;

public class InventoryResponse
{
    public InventoryResponse(Inventory.Core.Models.Inventory inventory)
    {
        Inventory = inventory;
    }

    public Inventory.Core.Models.Inventory Inventory { get; }
}