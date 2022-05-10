namespace Inventory.Core.Business.Validators;

public static class InventoryItemValidator
{
    public static bool IsNameValid(string name) 
        => !string.IsNullOrWhiteSpace(name) && name.Length <= 64;
    
    public static bool IsCountValid(int count) 
        => count >= 0;

    public static bool IsPricePerItemValid(double? pricePerItem) 
        => pricePerItem is null or >= 0.0;
}