using Inventory.Core.Business.Gateways.Inventory;
using Inventory.Database.Context;
using Inventory.Gateways.Abstract;

namespace Inventory.Gateways.DatabaseGateways.Inventory;

public class CreateInventoryGateway : BaseDatabaseGateway, ICreateInventoryGateway
{
    public CreateInventoryGateway(InventoryContext context) : base(context)
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