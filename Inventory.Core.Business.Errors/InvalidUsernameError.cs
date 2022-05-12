using Inventory.Core.Business.Errors.Abstract;

namespace Inventory.Core.Business.Errors;

public class InvalidUsernameError : IError
{
    public int Code { get; } = 1005;

    public string Message { get; } =
        "Username must be between 4 and 32 characters an must " 
        + "contain at least one letter and no special characters";
}