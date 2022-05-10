using Inventory.Core.Business.Errors.Abstract;

namespace Inventory.Core.Business.Errors;

public class InvalidPricePerItemError : IError
{
    public int Code { get; } = 1005;
    public string Message { get; } = "The price per item must not be less than 0.0";
}