using Microsoft.EntityFrameworkCore;
using MovieTheater.Core.Repository.Data;
using MovieTheater.Core.Repository.Models;

namespace MovieTheater.Core.Repository.Repositories;
/// <summary>
///     Service only for Admins who supports the system
/// </summary>
public class AdminRestService
{
    private readonly MovieTheaterDatabase database;
    public AdminRestService(MovieTheaterDatabase movieTheaterDatabase)
    {
        database = movieTheaterDatabase;
    }

    public async Task<CinemaHall?> GetOneCinemaHall(int id) => default;
    public async Task<List<CinemaHall>?> GetAllCinemaHalls() => default;
    public async Task<int> AddNewCinemaHall(string hallName, HallType type) => default;
    public async Task<int> UpdateCinemaHall(CinemaHall hall) => default;
    public async Task<int> DeleteCinemaHall(int id) => default;
    
}
