using System.ComponentModel.DataAnnotations.Schema;

namespace lw7.Models;

[Table("developer")]
public class Developer
{
    [Column("id")]
    public int? Id { get; set; }
    [Column("name")]
    public string? Name { get; set; }

    public List<Game>? Games { get; set; }

    public Developer() {}

    public Developer(int id, string name, List<Game> games)
    {
        Id = id;
        Name = name;
        Games = games;
    }
}