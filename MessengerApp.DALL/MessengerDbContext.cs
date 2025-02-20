using MessengerApp.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessengerApp.DALL
{
    public class MessengerDbContext : DbContext
    {
        private readonly string _connectionString;

        public DbSet<Person> Persons { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Chat> Chats { get; set; }
        public DbSet<Message> Message { get; set; }
        public DbSet<PersonsInChat> UsersInChats { get; set; }
        public DbSet<MessagesInChat> MessagesInChat { get; set; }

        public MessengerDbContext(string connectionString)
        {
            _connectionString = connectionString;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(_connectionString);
        }
    }
}