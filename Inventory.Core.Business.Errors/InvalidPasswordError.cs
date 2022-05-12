using Inventory.Core.Business.Errors.Abstract;

namespace Inventory.Core.Business.Errors;

public class InvalidPasswordError : IError
{
    public int Code { get; } = 1006;

    public string Message { get; } =
        "Password must be between 8 and 32 characters and must contain " 
        + "at least lowercase letters, uppercase letters, digits and special characters";
}