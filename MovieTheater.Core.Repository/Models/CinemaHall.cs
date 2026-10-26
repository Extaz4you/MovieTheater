using System.ComponentModel.DataAnnotations;

namespace MovieTheater.Core.Repository.Models;

public class CinemaHall
{
    public int Id { get; set; }
    public string HallName { get; set; }
    public int Capacity { get; set; }

    public List<Session> Sessions { get; set; } = new();

}


