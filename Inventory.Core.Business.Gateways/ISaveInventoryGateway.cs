namespace Inventory.Core.Business.Gateways;

public interface ISaveInventoryGateway
{
    Models.Inventory Save(string name);
}