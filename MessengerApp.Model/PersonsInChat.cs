namespace MessengerApp.Model;

public class PersonsInChat
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public Guid ChatId { get; set; }
    public Guid PersonId { get; set; }
    public Chat Chat { get; set; }
    public Person Person { get; set; }
}
