namespace Inventory.Core.Models;

public class InventoryItem
{
    public string Name { get; set; } = null!;
    public int Count { get; set; }
    public double? PricePerItem { get; set; }
    public string? AdditionalInformation { get; set; }
}