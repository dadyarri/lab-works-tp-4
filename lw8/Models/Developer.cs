using System.ComponentModel.DataAnnotations.Schema;

namespace lw7.Models;

[Table("Developer")]
public class Developer
{
    public int? Id { get; set; }
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