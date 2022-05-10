namespace Inventory.Core.Models;

public class Inventory
{
    public string Name { get; set; } = null!;
    public IList<InventoryItem> Items { get; set; } = new List<InventoryItem>();
}