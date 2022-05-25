using lw7.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace lw7.Data
;

public class ApplicationContext: IdentityDbContext
{
    public DbSet<Game> Games { get; set; }

    public ApplicationContext(DbContextOptions<ApplicationContext> options): base(options)
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