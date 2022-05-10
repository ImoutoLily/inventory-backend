namespace Inventory.Core.Business.Models.Request;

public class InventoryItemRequest
{
    public string Name { get; set; } = null!;
    public int Count { get; } = 0;
    public double? PricePerItem { get; set; }
    public string? AdditionalInformation { get; set; }
}