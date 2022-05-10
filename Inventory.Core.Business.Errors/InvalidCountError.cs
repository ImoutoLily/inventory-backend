using Inventory.Core.Business.Errors.Abstract;

namespace Inventory.Core.Business.Errors;

public class InvalidCountError : IError
{
    public int Code { get; } = 1004;
    public string Message { get; } = "The count must not be less than zero";
}