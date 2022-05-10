using System.Reflection;
using Inventory.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace Inventory.Database.Context;

public class InventoryContext : DbContext
{
    public DbSet<Core.Models.Inventory> Inventories { get; set; } = null!;
    public DbSet<InventoryItem> InventoryItems { get; set; } = null!;
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}