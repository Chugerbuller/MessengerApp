using System.Text.Json;
using System.Text.RegularExpressions;

namespace MessengerApp.WebApi.Helpers;

public class LoginAndPasswordValidation
{
    private readonly ValidationRules _rules;

    public LoginAndPasswordValidation()
    {
        var json = File.ReadAllText("ValidationRules.json");
        _rules = JsonSerializer.Deserialize<ValidationRules>(json)!;
    }

    public bool CheckLogin(string login) =>
        login.Length >= 5 &&
        Regex.IsMatch(login, @"^[a-zA-Z0-9_]+$");

    public bool CheckPassword(string password)
    {

        if (string.IsNullOrWhiteSpace(password)
            && password.Length < 7)
            return false;

        var checkSymbols = false;

        foreach (var sym in _rules.Symbols)
            if (password.Contains(sym))
                checkSymbols = true;

        var checkNumbers = false;

        foreach (var sym in _rules.Numbers)
            if (password.Contains(sym))
                checkNumbers = true;

        var checkUpperCase = false;
        var checkLowerCase = false;

        foreach (var sym in password)
        {
            if (Char.IsUpper(sym))
                checkUpperCase = true;
            if (Char.IsLower(sym))
                checkLowerCase = true;
        }

        return checkSymbols && checkNumbers && checkUpperCase && checkLowerCase;
    }
}