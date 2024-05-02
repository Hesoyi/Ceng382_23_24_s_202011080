using Microsoft.EntityFrameworkCore;
using ReservationApp.Models;

public class AppDbContext : DbContext
{
    public DbSet<Reservation> Reservations { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=ReservationDb;Trusted_Connection=True;");
    }
}
