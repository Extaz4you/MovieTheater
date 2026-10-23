namespace MovieTheater.Core.Repository.Models;

public class Ticket
{
    public int Id { get; set; }

    public int SessionId { get; set; }
    public Session Session { get; set; } = null!;
    public int SeatNumber { get; set; }

}
