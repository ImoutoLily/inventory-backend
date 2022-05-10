using Inventory.Core.Models;

namespace Inventory.Core.Business.Gateways;

public interface IUpdateInventoryItemGateway
{
    Task<InventoryItem?> Update(int id, string name, int? count, double? pricePerItem,
        string? additionalInformation);
}