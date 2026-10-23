using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design.Internal;
using MovieTheater.Core.Repository.Data;

namespace MovieTheater.Core.Repository.Repositories;

/// <summary>
///  REST Service for Movies and informations of movies
///  This service only for admins and persons with full accesses
/// </summary>
public class MovieRestService
{
    public readonly MovieTheaterDatabase database;

    public MovieRestService(MovieTheaterDatabase movieTheaterDatabase)
    {
        database = movieTheaterDatabase;
    }

    public async Task<bool> GetMovie(int id)
    {
        return default;
    }

    public async Task<bool> AddMovie()
    {
        return default;
    }

    public async Task<bool> DeleteMovie()
    {
        return default;
    }

    public async Task<bool> EditMovie()
    {
        return default;
    }
}
