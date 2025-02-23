using MessengerApp.DAL;
using MessengerApp.WebApi.Helpers;
using MessengerApp.WebApi.Hubs;

namespace MessengerApp.WebApi;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddControllers();
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();
        builder.Services.AddSignalR();
        builder.Services.AddTransient<MessengerDbContextFactory>();
        builder.Services.AddTransient<HashHelper>();
        builder.Services.AddTransient<LoginAndPasswordValidation>();
        
        var app = builder.Build();

        app.MapHub<MessengerHub>("/messenger");
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();
        app.MapControllers();

        app.Run();
    }
}
