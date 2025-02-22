using System.Text.Json.Serialization;

namespace MessengerApp.Model;

public class Message
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string MessageContent { get; set; }
    public DateTime Created { get; set; } = DateTime.Now;
    public Guid PersonId { get; set; }
    public Person Person { get; set; }
    [JsonIgnore]
    public List<MessagesInChat>? MessagesInChats { get; set; }
}