namespace Inventory.Core.Business.Errors;

public class InvalidInventoryNameError : IError
{
    public int Code { get; } = 1000;
    public string Message { get; } = "Inventory name must not be empty";
}