using Inventory.Core.Business.Errors;
using Inventory.Core.Business.Gateways.Authentication;
using Inventory.Core.Business.Models;
using Inventory.Core.Business.Validators;
using Inventory.Core.Models;

namespace Inventory.Core.Business.Authentication;

public class Authenticate
{
    private readonly IAuthenticateGateway _authenticate;

    public Authenticate(IAuthenticateGateway authenticate)
    {
        _authenticate = authenticate;
    }

    public async Task<Result<User>> Login(AuthenticateRequest request)
    {
        if (string.IsNullOrWhiteSpace(request.Email) && string.IsNullOrWhiteSpace(request.Username)) 
            return Result.Fail<User>(new NoEmailOrUsernameSpecifiedError());
        
        var user = await _authenticate.Login(request.Email, request.Username, request.Password);
        
        return user is null 
            ? Result.Fail<User>(new InvalidCredentialsError()) 
            : Result.Ok(user);
    }

    public async Task<Result<User>> Register(AuthenticateRequest request)
    {
        if (!UserValidator.IsUsernameValid(request.Username))
            return Result.Fail<User>(new InvalidUsernameError());
        if (!UserValidator.IsPasswordValid(request.Password))
            return Result.Fail<User>(new InvalidPasswordError());

        var user = await _authenticate.Register(request.Email, request.Username, request.Password);
        
        return user is null 
            ? Result.Fail<User>(new UsernameAlreadyInUseError()) 
            : Result.Ok(user);
    }
}