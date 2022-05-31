namespace lw7.Models;

public class DeveloperGames
{
    public Developer Developer { get; set; }
    public IEnumerable<Game> Games { get; set; }

    public DeveloperGames(Developer developer, IEnumerable<Game> games)
    {
        Developer = developer;
        Games = games;
    }
}