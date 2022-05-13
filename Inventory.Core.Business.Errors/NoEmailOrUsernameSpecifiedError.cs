using Inventory.Core.Business.Errors.Abstract;

namespace Inventory.Core.Business.Errors;

public class NoEmailOrUsernameSpecifiedError : IError
{
    public int Code { get; } = 1009;
    public string Message { get; } = "There was no email or username provided.";
}