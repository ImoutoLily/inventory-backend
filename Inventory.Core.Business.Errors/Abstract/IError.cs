namespace Inventory.Core.Business.Errors.Abstract;

public interface IError
{
    int Code { get; }
    string Message { get; }
}