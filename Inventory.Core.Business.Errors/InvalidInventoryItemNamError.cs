using Inventory.Core.Business.Errors.Abstract;

namespace Inventory.Core.Business.Errors;

public class InvalidInventoryItemNamError : IError
{
    public int Code { get; } = 1003;
    public string Message { get; } = "Inventory item name must not be empty and must not be larger than 64 characters";
}