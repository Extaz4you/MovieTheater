namespace MovieTheater.Core.Repository.Models;

public class Session
{
    public int Id { get; set; }
    public int MovieId { get; set; }
    public Movie Movie { get; set; } = null!;
    public int CinemaHallId { get; set; }
    public CinemaHall CinemaHall { get; set; } = null!;
    public DateTime StartTime { get; set; }

    public List<Ticket> Tickets { get; set; } = new();

}
