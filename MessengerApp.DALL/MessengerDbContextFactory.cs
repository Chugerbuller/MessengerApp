using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
namespace MessengerApp.DAL;

public class MessengerDbContextFactory : IDesignTimeDbContextFactory<MessengerDbContext>
{
    public MessengerDbContext CreateDbContext(string[] args)
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

        return new MessengerDbContext(connectionString);
    }

    private string[] args = [];

    public MessengerDbContext CreateDbContext()
    {
        return CreateDbContext(args);
    }
}  
