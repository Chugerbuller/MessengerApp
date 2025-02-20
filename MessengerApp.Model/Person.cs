using System.Text.Json.Serialization;

namespace MessengerApp.Model;

public class Person
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string LastName { get; set; }
    public string FirstName { get; set; }
    [JsonIgnore]
    public ICollection<User>? Users { get; set; }
    [JsonIgnore]
    public List<PersonsInChat>? UsersInChat { get; set; }
}
