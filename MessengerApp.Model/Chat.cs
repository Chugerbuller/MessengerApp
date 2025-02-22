using System.Text.Json.Serialization;

namespace MessengerApp.Model;

public class Chat
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public required string ChatName { get; set; }
    [JsonIgnore]
    public List<PersonsInChat>? PersonsInChat { get; set; }
    [JsonIgnore]
    public List<MessagesInChat>? MessagesInChats { get; set; }
}
