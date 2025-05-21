using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using FlightLibrary.Model;

namespace FlightStatusHub
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container  
            builder.Services.AddSignalR();

            // Add EF Core & Repository services
            builder.Services.AddDbContext<AppDbContext>(options =>
                options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

            // Register Repository
            builder.Services.AddScoped<IFlightRepository, FlightRepository>();

            // Register FlightService (IFlightService болон FlightService заавал үүссэн байх шаардлагатай)
            builder.Services.AddScoped<IFlightService, FlightService>();

            // Hosted service, controllers, CORS
            builder.Services.AddHostedService<Worker>();
            builder.Services.AddControllers();
            builder.Services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy", builder =>
                {
                    builder
                        .AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader();
                });
            });

            var app = builder.Build();

            // Холболтыг шалгах (Build хийсний дараа, DI ашиглан)
            using (var scope = app.Services.CreateScope())
            {
                var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();
                if (context.Database.CanConnect())
                {
                    Console.WriteLine("Success");
                }
                else
                {
                    
                    Console.WriteLine("Bad request");
                }
            }

            // Configure the HTTP request pipeline  
            app.UseCors("CorsPolicy");

            app.MapControllers();
            app.MapHub<FlightStatusHub>("/flightStatusHub");

            app.Run();
        }
    }
}
