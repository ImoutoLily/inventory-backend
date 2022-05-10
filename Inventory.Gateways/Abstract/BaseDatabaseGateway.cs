using Inventory.Database.Context;

namespace Inventory.Gateways.Abstract;

public abstract class BaseDatabaseGateway
{
    protected readonly InventoryContext Context;

    protected BaseDatabaseGateway(InventoryContext context)
    {
        Context = context;
    }
}