using StripsBL.Interfaces;
using StripsBL.Managers;
using StripsDL.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace StripsREST
{
    public class Program
    {
        public static void Main(string[] args)
        {
            string connectionString = "Server=LAPTOP-8H8592P3\\SQLEXPRESS;Database=Strips;Integrated Security=True;";
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            

            // Register the StripsManager and its dependencies
            builder.Services.AddHttpContextAccessor();
            builder.Services.AddScoped<IStripsRepository>(provider => new StripsRepository(connectionString));
            builder.Services.AddScoped<StripsManager>();

            // ... any other services your application needs

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}