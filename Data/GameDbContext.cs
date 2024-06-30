using GameStore.Entities;
using Microsoft.EntityFrameworkCore;

namespace GameStore.Data;


public class GameDbContext(DbContextOptions<GameDbContext> options) : DbContext(options)
{
    // Expression-bodied properties (read-only)
    public DbSet<Game> Games => Set<Game>();
    public DbSet<Genre> Genres => Set<Genre>();

    //soon as the migratio gets tp run below runs 
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // lo lets create some hardcoded data
        modelBuilder.Entity<Genre>().HasData(
            new {Id=1,Name="Fighting"},
            new {Id=2,Name="Swimming"}
        );

    }
}