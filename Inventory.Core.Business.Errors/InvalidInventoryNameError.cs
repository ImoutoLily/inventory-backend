namespace Inventory.Core.Business.Errors;

public class InvalidInventoryNameError : IError
{
    public int Code { get; } = 1000;
    public string Message { get; } = "Inventory name must not be empty and must not be larger than 64 characters";
}