using Inventory.Core.Business.Errors.Abstract;

namespace Inventory.Core.Business.Errors;

public class InvalidCredentialsError : IError
{
    public int Code { get; } = 1007;
    public string Message { get; } = "Invalid username / password combination";
}