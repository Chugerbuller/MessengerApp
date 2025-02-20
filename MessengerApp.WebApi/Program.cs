
using MessengerApp.DALL;
using MessengerApp.WebApi.Helpers;
using MessengerApp.WebApi.Hub;

namespace MessengerApp.WebApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddSignalR();
            builder.Services.AddTransient<MessengerDbContextFactory>();
            builder.Services.AddTransient<HashHelper>();
            builder.Services.AddTransient<LoginAndPasswordValidation>();
            
            var app = builder.Build();

            app.MapHub<MessengerHub>("/messenger");

            // Configure the HTTP request pipeline.
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
}
