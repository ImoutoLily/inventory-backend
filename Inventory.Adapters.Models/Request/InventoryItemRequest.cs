namespace Inventory.Adapters.Models.Request;

public class InventoryItemRequest
{
    public string Name { get; set; } = null!;
    public int? Count { get; set; }
    public double? PricePerItem { get; set; }
    public string? AdditionalInformation { get; set; }
}