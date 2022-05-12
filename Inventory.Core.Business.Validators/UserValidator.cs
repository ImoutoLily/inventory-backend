using System.Text.RegularExpressions;

namespace Inventory.Core.Business.Validators;

public static class UserValidator
{
    public static bool IsUsernameValid(string username)
        => Regex.IsMatch(username, 
            "^(?=.*[a-zA-Z])(?=.*[\\d])(?=.*[\\-_ ])[a-zA-Z\\d\\-_]{4,32}$");

    public static bool IsPasswordValid(string password) 
        => Regex.IsMatch(password, 
            "^(?=.*[a-z])(?=.*[A-Z])(?=.*\\d)(?=.*[@$!%*?&])[A-Za-z\\d@$!%*?&]{8,32}$");
}