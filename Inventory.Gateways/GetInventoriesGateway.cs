using Inventory.Core.Business.Gateways;
using Inventory.Database.Context;
using Microsoft.EntityFrameworkCore;

namespace Inventory.Gateways;

public class GetInventoriesGateway : IGetInventoriesGateway
{
    private readonly InventoryContext _context;

    public GetInventoriesGateway(InventoryContext context)
    {
        _context = context;
    }
    
    public async Task<Core.Models.Inventory?> GetById(int id)
    {
        var inventory = await _context.Inventories
            .SingleOrDefaultAsync(i => i.Id == id);

        return inventory;
    }

    public async Task<IList<Core.Models.Inventory>> GetAll()
    {
        var inventories = await _context.Inventories
            .ToListAsync();

        return inventories;
    }
}