using Microsoft.AspNetCore.Identity;

namespace Inventory.Database.Context.Models;

public class DatabaseUser : IdentityUser
{
    public IList<Core.Models.Inventory> Inventories { get; set; } = new List<Core.Models.Inventory>();
}