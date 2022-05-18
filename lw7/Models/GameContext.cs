using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace lw7.Models;

public sealed class GameContext : IdentityDbContext
{
    public DbSet<Game>? Games { get; set; }
    public DbSet<Developer>? Developers { get; set; }

    public GameContext(DbContextOptions<GameContext> options) : base(options)
    {
        Database.EnsureCreated();
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Game>()
            .HasOne(g => g.Developer)
            .WithMany(d => d.Games);
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json")
            .Build();

        var connectionString = configuration.GetConnectionString("Default");
        optionsBuilder.UseNpgsql(connectionString);
    }
}