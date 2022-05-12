using Inventory.Core.Business.Errors;
using Inventory.Core.Business.Gateways.Authentication;
using Inventory.Core.Business.Models.Core;
using Inventory.Core.Business.Models.Request;
using Inventory.Core.Business.Models.Response;
using Inventory.Core.Business.Validators;

namespace Inventory.Core.Business.Authentication;

public class Authenticate
{
    private readonly IAuthenticateGateway _authenticate;

    public Authenticate(IAuthenticateGateway authenticate)
    {
        _authenticate = authenticate;
    }

    public async Task<Result<AuthenticationResponse>> Login(AuthenticationRequest request)
    {
        var user = await _authenticate.Login(request.Username, request.Password);
        
        return user is null 
            ? Result.Fail<AuthenticationResponse>(new InvalidCredentialsError()) 
            : Result.Ok(new AuthenticationResponse(user.Id, user.UserName));
    }

    public async Task<Result<AuthenticationResponse>> Register(AuthenticationRequest request)
    {
        if (!UserValidator.IsUsernameValid(request.Username))
            return Result.Fail<AuthenticationResponse>(new InvalidUsernameError());
        if (!UserValidator.IsPasswordValid(request.Password))
            return Result.Fail<AuthenticationResponse>(new InvalidPasswordError());

        var user = await _authenticate.Register(request.Username, request.Password);
        
        return user is null 
            ? Result.Fail<AuthenticationResponse>(new UsernameAlreadyInUseError()) 
            : Result.Ok(new AuthenticationResponse(user.Id, user.UserName));
    }
}