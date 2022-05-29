using System.ComponentModel.DataAnnotations.Schema;

namespace lw7.Models;

public class Game
{
    public int? Id { get; set; }
    public string? Title { get; set; }
    public Developer? Developer { get; set; }
    public string? Genre { get; set; }

    public Game() { }

    public Game(int id, string title, Developer developer, string genre)
    {
        Id = id;
        Title = title;
        Developer = developer;
        Genre = genre;
    }
}