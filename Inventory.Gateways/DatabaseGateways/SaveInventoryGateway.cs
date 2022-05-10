using Inventory.Core.Business.Gateways;
using Inventory.Database.Context;
using Inventory.Gateways.Abstract;

namespace Inventory.Gateways.DatabaseGateways;

public class SaveInventoryGateway : BaseDatabaseGateway, ISaveInventoryGateway
{
    public SaveInventoryGateway(InventoryContext context) : base(context)
    {
    }

    public async Task<Core.Models.Inventory> Save(string name)
    {
        var inventory = new Core.Models.Inventory
        {
            Name = name
        };

        Context.Inventories.Add(inventory);

        await Context.SaveChangesAsync();

        return inventory;
    }
}