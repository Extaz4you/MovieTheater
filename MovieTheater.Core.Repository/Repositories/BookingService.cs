using MovieTheater.Core.Repository.Data;

namespace MovieTheater.Core.Repository.Repositories;

public class BookingService
{
    private readonly MovieTheaterDatabase database;

    public BookingService(MovieTheaterDatabase movieTheaterDatabase)
    {
        database = movieTheaterDatabase;
    }

    public async Task<int> MakeReservation()
    {
        return default;
    }
    public async Task<int> CancelReservation()
    {
        return default;
    }
}
