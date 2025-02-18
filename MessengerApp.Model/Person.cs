namespace MessengerApp.Model;

public class Person
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string LastName { get; set; }
    public string FirstName { get; set; }
    public List<User>? Users { get; set; }
    public List<PersonsInChat>? UsersInChat { get; set; }
}
