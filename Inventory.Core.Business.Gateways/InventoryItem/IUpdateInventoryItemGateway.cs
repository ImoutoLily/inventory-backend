namespace Inventory.Core.Business.Gateways.InventoryItem;

public interface IUpdateInventoryItemGateway
{
    Task<Models.InventoryItem?> Update(int id, string name, int? count, double? pricePerItem,
        string? additionalInformation);
}