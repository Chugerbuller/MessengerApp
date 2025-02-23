namespace MessengerApp.WebApi.Helpers;

public enum Methods
{
    ReciveMsg,
    SendMsg,
    EnterInMessenger
}

public class MethodsHelper
{
    public Dictionary<Methods, string> MethodsMap { get; } = new()
    {
        {Methods.ReciveMsg, "ReciveMsg" },
        {Methods.SendMsg, "SendMsg" },
        {Methods.EnterInMessenger, "EnterInMessenger" },
    };
}