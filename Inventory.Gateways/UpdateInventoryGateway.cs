using Inventory.Core.Business.Gateways;
using Inventory.Database.Context;
using Microsoft.EntityFrameworkCore;

namespace Inventory.Gateways;

public class UpdateInventoryGateway : IUpdateInventoryGateway
{
    private readonly InventoryContext _context;

    public UpdateInventoryGateway(InventoryContext context)
    {
        _context = context;
    }

    public async Task<Core.Models.Inventory?> UpdateInventory(int id, string newName)
    {
        var inventory = await _context.Inventories
            .SingleOrDefaultAsync(i => i.Id == id);

        if (inventory is null) return null;

        inventory.Name = newName;

        await _context.SaveChangesAsync();

        return inventory;
    }
}