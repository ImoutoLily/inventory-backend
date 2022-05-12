namespace Inventory.Core.Business.Models.Response;

public class AuthenticationResponse
{
    public AuthenticationResponse(string id, string username)
    {
        Id = id;
        Username = username;
    }

    public string Id { get; set; }
    public string Username { get; set; }
}