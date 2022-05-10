namespace Inventory.Core.Business.Validators;

public static class InventoryItemValidator
{
    public static bool IsNameValid(string name) 
        => !string.IsNullOrWhiteSpace(name) && name.Length <= 64;
}