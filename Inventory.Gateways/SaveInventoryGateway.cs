using Inventory.Core.Business.Gateways;
using Inventory.Database.Context;

namespace Inventory.Gateways;

public class SaveInventoryGateway : ISaveInventoryGateway
{
    private readonly InventoryContext _context;

    public SaveInventoryGateway(InventoryContext context)
    {
        _context = context;
    }

    public async Task<Core.Models.Inventory> Save(string name)
    {
        var inventory = new Core.Models.Inventory
        {
            Name = name
        };

        _context.Inventories.Add(inventory);

        await _context.SaveChangesAsync();

        return inventory;
    }
}