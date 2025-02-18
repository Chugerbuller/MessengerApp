namespace MessengerApp.Model;

public class User
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string Login { get; set; }
    public string Password { get; set; }
    public Guid PersonID { get; set; }
    public Person? Person { get; set; }

}