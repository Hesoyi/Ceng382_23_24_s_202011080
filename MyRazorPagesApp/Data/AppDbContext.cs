using Microsoft.EntityFrameworkCore;
using MyRazorPagesApp.Model;

namespace MyRazorPagesApp.Data{
public class AppDbContext : DbContext
{
public AppDbContext(DbContextOptions<AppDbContext> options) :
base(options)
{
}
public DbSet<Room> Rooms { get; set; }
}
}
