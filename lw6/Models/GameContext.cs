using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace lw6.Models;

public class GameContext: IdentityDbContext
{
    public DbSet<Game> Games { get; set; }

    public GameContext(DbContextOptions<GameContext> options): base(options)
    {
        Database.EnsureCreated();
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