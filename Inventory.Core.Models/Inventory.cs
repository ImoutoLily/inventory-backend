namespace Inventory.Core.Models;

public class Inventory
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public string CreatorId { get; set; } = null!;
    public IList<InventoryItem> Items { get; set; } = new List<InventoryItem>();
}