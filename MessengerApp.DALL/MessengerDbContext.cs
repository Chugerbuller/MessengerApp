using MessengerApp.Model;
using Microsoft.EntityFrameworkCore;

namespace MessengerApp.DAL;

public class MessengerDbContext : DbContext
{
    private readonly string _connectionString;

    public DbSet<Person> Persons { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<Chat> Chats { get; set; }
    public DbSet<Message> Message { get; set; }
    public DbSet<PersonsInChat> PersonsInChat { get; set; }
    public DbSet<MessagesInChat> MessagesInChat { get; set; }

    public MessengerDbContext(string connectionString)
    {
        _connectionString = connectionString;
        Message.Load();
        Chats.Load();
        Persons.Load();
        Users.Load();
        MessagesInChat.Load();
        PersonsInChat.Load();
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql(_connectionString);
    }
}