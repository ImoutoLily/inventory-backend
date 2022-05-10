using Inventory.Core.Business.Gateways;
using Inventory.Database.Context;
using Inventory.Gateways.Abstract;
using Microsoft.EntityFrameworkCore;

namespace Inventory.Gateways.DatabaseGateways;

public class GetInventoriesGateway : BaseDatabaseGateway, IGetInventoriesGateway
{
    public GetInventoriesGateway(InventoryContext context) : base(context)
    {
    }
    
    public async Task<Core.Models.Inventory?> GetById(int id)
    {
        var inventory = await Context.Inventories
            .SingleOrDefaultAsync(i => i.Id == id);

        return inventory;
    }

    public async Task<IList<Core.Models.Inventory>> GetAll()
    {
        var inventories = await Context.Inventories
            .ToListAsync();

        return inventories;
    }
}