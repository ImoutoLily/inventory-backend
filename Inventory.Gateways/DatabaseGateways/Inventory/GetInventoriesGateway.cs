using Inventory.Core.Business.Gateways.Inventory;
using Inventory.Database.Context;
using Inventory.Gateways.Abstract;
using Microsoft.EntityFrameworkCore;

namespace Inventory.Gateways.DatabaseGateways.Inventory;

public class GetInventoriesGateway : BaseDatabaseGateway, IGetInventoriesGateway
{
    public GetInventoriesGateway(InventoryContext context) : base(context)
    {
    }
    
    public async Task<Core.Models.Inventory?> GetById(int id)
    {
        var inventory = await Context.Inventories
            .Include(i => i.Items)
            .SingleOrDefaultAsync(i => i.Id == id);

        return inventory;
    }

    public async Task<IList<Core.Models.Inventory>> GetAll()
    {
        var inventories = await Context.Inventories
            .Include(i => i.Items)
            .ToListAsync();

        return inventories;
    }
}