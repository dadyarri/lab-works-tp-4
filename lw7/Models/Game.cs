using System.ComponentModel.DataAnnotations.Schema;

namespace lw7.Models;

[Table("game")]
public class Game
{
    [Column("id")]
    public int? Id { get; set; }
    [Column("title")]
    public string? Title { get; set; }
    [Column("developer")]
    public Developer? Developer { get; set; }
    [Column("genre")]
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