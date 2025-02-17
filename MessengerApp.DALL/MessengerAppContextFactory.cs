using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessengerApp.DALL
{
    public class MessengerAppContextFactory : IDesignTimeDbContextFactory<MessengerAppContext>
    {
        public MessengerAppContext CreateDbContext(string[] args)
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();
#if DEBUG
            var connectionString = config.GetConnectionString("TestConnection");
#elif RELEASE
        var connectionString = config.GetConnectionString("ProductionConnection");
#endif

            return new MessengerAppContext(connectionString);
        }

        private string[] args = [];

        public MessengerAppContext CreateDbContext()
        {
            return CreateDbContext(args);
        }
    }  
}
