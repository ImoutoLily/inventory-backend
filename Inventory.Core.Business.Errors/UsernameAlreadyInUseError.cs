using Inventory.Core.Business.Errors.Abstract;

namespace Inventory.Core.Business.Errors;

public class UsernameAlreadyInUseError : IError
{
    public int Code { get; } = 1009;
    public string Message { get; } = "Username is already in use";
}