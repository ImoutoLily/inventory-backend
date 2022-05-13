namespace Inventory.Core.Models;

public class User
{
    public string Id { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string UserName { get; set; } = null!;
    public IList<Inventory> Inventories { get; set; } = new List<Inventory>();
}