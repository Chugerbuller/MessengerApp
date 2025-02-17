using MessengerApp.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessengerApp.DALL
{

    public class MessengerAppContext:DbContext
    {
        private readonly string _connectionString;

        public DbSet<Person> Persons { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Chat> Chats { get; set; }
        public DbSet<Messege> Messeges { get; set; }
        public DbSet<UsersInChat> UsersInChats { get; set; }
        public DbSet<MessengesInChat> MessengesInChats { get; set; }

        public  MessengerAppContext  (string connectionString)
        {
            _connectionString = connectionString;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(_connectionString);
               
        }
    }
}
