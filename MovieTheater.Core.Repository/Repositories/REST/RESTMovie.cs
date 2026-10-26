using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client.NativeInterop;
using MovieTheater.Core.Repository.Data;
using MovieTheater.Core.Repository.Models;
using MovieTheater.Core.Repository.Models.DTO;

namespace MovieTheater.Core.Repository.Repositories.REST;
/// <summary>
/// Movie management service. For everyone.
/// </summary>
public class RESTMovie
{
    private readonly MovieTheaterDatabase database;

    public RESTMovie(MovieTheaterDatabase movieTheaterDatabase)
    {
        database = movieTheaterDatabase;
    }

    public async Task<List<Movie>?> GetMovies(string name) => await database.Movies.Where(x => x.MovieName.Contains(name)).ToListAsync();


    public async Task<InfoMessage> AddMovie(DTOMovie movie)
    {
        var IsThereAMovie = await database.Movies.AnyAsync(x => x.MovieName == movie.Name);
        if (IsThereAMovie) return new InfoMessage("You are trying to add a duplicate", 409);

        var newMovie = new Movie() { MovieName = movie.Name, Duration = movie.Duration };

        await database.Movies.AddAsync(newMovie);
        await database.SaveChangesAsync();

        return new InfoMessage($"Successfully added, movie id is {newMovie.Id}", 200);

    }

    public async Task<InfoMessage> EditMovie(int id, DTOMovie editeMovie)
    {
        if (editeMovie == null || editeMovie.Name == null) return new InfoMessage("Something wrong with the request. Doesn't have any movie", 404);
        var oldMovie = await database.Movies.FirstOrDefaultAsync(x => x.Id == id);
        if (oldMovie == null) return new InfoMessage("Couldn't find that movie", 204);
        oldMovie.MovieName = editeMovie.Name;
        oldMovie.Duration = editeMovie.Duration;

        await database.SaveChangesAsync();

        return new InfoMessage("Successful update", 200);
    }

    public async Task<InfoMessage> DeleteMovie(int id)
    {
        var count = await database.Movies.Where(x=>x.Id == id).ExecuteDeleteAsync();
        if(count>0) return new InfoMessage("Successful deletion", 200);
        else return new InfoMessage("Couldn't complete the deletion process", 200);
    }

    public record InfoMessage(string Message, int Code);
}
