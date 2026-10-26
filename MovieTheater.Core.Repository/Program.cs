
using Microsoft.EntityFrameworkCore;
using MovieTheater.Core.Repository.Data;
using MovieTheater.Core.Repository.Models;
using MovieTheater.Core.Repository.Repositories.REST;

namespace MovieTheater.Core.Repository
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddControllers();

            builder.Services.AddDbContext<MovieTheaterDatabase>(o => o.UseSqlServer(builder.Configuration.GetConnectionString("Connection")));
            builder.Services.AddScoped<RESTMovie>();
            builder.Services.AddScoped<RESTCinemaHall>();

            var app = builder.Build();

            app.UseSwagger();
            app.UseSwaggerUI();


            app.UseAuthorization();
            app.MapControllers();

            app.Run();
        }
    }
}
