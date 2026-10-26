using MovieTheater.Core.Repository.Data;
using MovieTheater.Core.Repository.Models;

namespace MovieTheater.Core.Repository.Repositories;

public class BookingService
{
    private readonly MovieTheaterDatabase database;

    public BookingService(MovieTheaterDatabase movieTheaterDatabase)
    {
        database = movieTheaterDatabase;
    }

    public async Task<Ticket?> MakeReservation()
    {
        return default;
    }
    public async Task<Ticket?> CancelReservation()
    {
        return default;
    }
}
