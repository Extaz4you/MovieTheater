using Microsoft.EntityFrameworkCore;
using MovieTheater.Core.Repository.Models;

namespace MovieTheater.Core.Repository.Data;

public class MovieTheaterDatabase : DbContext
{
    public MovieTheaterDatabase(DbContextOptions options) : base(options)
    {

    }
    public DbSet<CinemaHall> CinemaHalls => Set<CinemaHall>();
    public DbSet<Movie> Movies => Set<Movie>();
    public DbSet<Session> Sessions => Set<Session>();
    public DbSet<Ticket> Tickets => Set<Ticket>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {

        modelBuilder.Entity<Movie>(entity =>
        {
            entity.Property(m => m.MovieName)
                  .HasMaxLength(200)
                  .IsRequired();

            entity.Property(m => m.Duration)
                  .IsRequired();

            entity.HasMany(m => m.Sessions)
                  .WithOne(s => s.Movie)
                  .HasForeignKey(s => s.MovieId)
                  .OnDelete(DeleteBehavior.Restrict);   // нельзя удалить фильм с сеансами
        });

        modelBuilder.Entity<CinemaHall>(entity =>
        {
            entity.Property(h => h.HallName)
                  .HasMaxLength(100)
                  .IsRequired();

            entity.Property(h => h.Capacity)
                  .IsRequired();

            entity.HasMany(h => h.Sessions)
                  .WithOne(s => s.CinemaHall)
                  .HasForeignKey(s => s.CinemaHallId)
                  .OnDelete(DeleteBehavior.Restrict);   // нельзя удалить зал с сеансами
        });

        modelBuilder.Entity<Session>(entity =>
        {
            entity.Property(s => s.StartTime)
                  .IsRequired();

            entity.HasMany(s => s.Tickets)
                  .WithOne(t => t.Session)
                  .HasForeignKey(t => t.SessionId)
                  .OnDelete(DeleteBehavior.Cascade);    // удалили сеанс — удалились билеты

            entity.HasIndex(s => new { s.CinemaHallId, s.StartTime });
        });

        modelBuilder.Entity<Ticket>(entity =>
        {
            entity.Property(t => t.SeatNumber)
                  .IsRequired();

            entity.HasIndex(t => new { t.SessionId, t.SeatNumber })
                  .IsUnique();
        });
    }
}
