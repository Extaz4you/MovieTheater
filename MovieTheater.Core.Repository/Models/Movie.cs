namespace MovieTheater.Core.Repository.Models;

public class Movie
{
    public int Id { get; set; }
    public string MovieName { get; set; }
    public TimeSpan Duration { get; set; }

    public List<Session> Sessions { get; set; } = new();

}
