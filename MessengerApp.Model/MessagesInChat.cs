namespace MessengerApp.Model;

public class MessagesInChat
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public Guid ChatId { get; set; }
    public Guid MessageId { get; set; }
    public Chat? Chat { get; set; }
    public Message? Message { get; set; }
}
