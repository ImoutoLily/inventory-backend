namespace Inventory.Core.Business.Models.Result;

public class GetInventoryByIdResult
{
    public GetInventoryByIdResult(Inventory.Core.Models.Inventory? inventory)
    {
        Inventory = inventory;
    }

    public Inventory.Core.Models.Inventory? Inventory { get; }
}