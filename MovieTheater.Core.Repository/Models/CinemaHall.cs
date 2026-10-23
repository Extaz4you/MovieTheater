using System.ComponentModel.DataAnnotations;

namespace MovieTheater.Core.Repository.Models;

public class CinemaHall
{
    public int Id { get; set; }
    public string HallName { get; set; }
    public int Capacity { get; set; }

    public List<Session> Sessions { get; set; } = new();

}


public enum HallType
{
    [Display(Name = "Standard (64 места)")]
    Standard = 64,
    [Display(Name = "VIP (32 места)")]
    VIP = 32,
    [Display(Name = "IMAX (24 места)")]
    IMAX = 24,
    [Display(Name = "Kids (16 мест)")]
    Kids = 16
}

