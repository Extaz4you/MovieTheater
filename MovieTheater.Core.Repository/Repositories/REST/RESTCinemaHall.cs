using Microsoft.EntityFrameworkCore;
using MovieTheater.Core.Repository.Data;
using MovieTheater.Core.Repository.Models;
using MovieTheater.Core.Repository.Models.DTO;
using System.Security.Cryptography.Xml;

namespace MovieTheater.Core.Repository.Repositories.REST;
/// <summary>
/// REST service only for admins to work with CinemaHalls
/// </summary>
public class RESTCinemaHall
{
    private readonly MovieTheaterDatabase database;
    public RESTCinemaHall(MovieTheaterDatabase movieTheaterDatabased)
    {
        database = movieTheaterDatabased;
    }

    public async Task<CinemaHall?> GetCinemaHall(string name)
    {
        return await database.CinemaHalls.FirstOrDefaultAsync(x => x.HallName == name);
    }

    public async Task<int> AddCinemaHall(CinemaHallDTO cinemaHall)
    {
        if (cinemaHall == null) return 0;

        var check = database.CinemaHalls.FirstOrDefaultAsync(x => x.HallName == cinemaHall.name);
        if (check != null) return check.Id;

        var newCinemaHall = new CinemaHall() { HallName = cinemaHall.name, Capacity = cinemaHall.capacity };
        await database.CinemaHalls.AddAsync(newCinemaHall);
        await database.SaveChangesAsync();

        return newCinemaHall.Id;
    }

    public async Task<int> EditCinemaHall(int id, CinemaHallDTO cinemaHall)
    {
        return await database.CinemaHalls.Where(x => x.Id == id)
            .ExecuteUpdateAsync(setter => setter
            .SetProperty(x => x.HallName, cinemaHall.name)
            .SetProperty(x => x.Capacity, cinemaHall.capacity));
    }

    public async Task<int> DeleteCinemaHall(int id) => await database.CinemaHalls.Where(x => x.Id == id).ExecuteDeleteAsync();

}
