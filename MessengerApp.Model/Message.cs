namespace MessengerApp.Model;

public class Message
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string MessageContent { get; set; }
    public List<MessagesInChat>? MessagesInChats { get; set; }
}
