using Microsoft.EntityFrameworkCore;
using MovieTheater.Core.Repository.Data;
using MovieTheater.Core.Repository.Models;
using System.Net.WebSockets;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace MovieTheater.Core.Repository.Repositories.REST;


/// <summary>
/// Service for working with Sessions. It's neceesary when creating tickets
/// </summary>
public class RESTSession
{

    private readonly MovieTheaterDatabase database;

    public RESTSession(MovieTheaterDatabase movieTheaterDatabase)
    {
        database = movieTheaterDatabase;
    }

    public async Task<Session?> GetSession(int id)
    {
        return await database.Sessions.Include(x=>x.Tickets).FirstOrDefaultAsync(x=>x.Id == id);
    }

    public async Task<int> AddSession(Movie movie, CinemaHall hall, DateTime date)
    {
        var IsThereSession = await database.Sessions.AnyAsync(x => x.MovieId == movie.Id && x.CinemaHallId == hall.Id && date <= x.StartTime + movie.Duration); 
        if(IsThereSession)  return 0;
        var newSession = new Session()
        {
            Movie = movie,
            MovieId = movie.Id,
            CinemaHall = hall,
            CinemaHallId = hall.Id,
            StartTime = date,
        };

        await database.Sessions.AddAsync(newSession);
        await database.SaveChangesAsync();
       return newSession.Id;
    }

    public async Task<bool> DeleteSession(Movie movie, CinemaHall hall, DateTime date)
    {
        var IsThereSession = await database.Sessions.FirstOrDefaultAsync(x => x.MovieId == movie.Id && x.CinemaHallId == hall.Id && x.StartTime == date);
        if (IsThereSession!= null)
        {
            database.Remove(IsThereSession);
            await database.SaveChangesAsync();
            return true;
        }
        return false;
    }


}
