using System.Reflection;
using Inventory.Core.Models;
using Inventory.Database.Context.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Inventory.Database.Context;

public class InventoryContext : IdentityDbContext<DatabaseUser>
{
    public DbSet<Core.Models.Inventory> Inventories { get; set; } = null!;
    public DbSet<InventoryItem> InventoryItems { get; set; } = null!;

    public InventoryContext(DbContextOptions<InventoryContext> options) : base(options)
    {
    }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}