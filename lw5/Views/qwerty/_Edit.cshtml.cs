using System.Data.Common;
using lw5.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Npgsql;

namespace lw5.Views.Home;

public class EditModel : PageModel
{
    private readonly ILogger _logger;

    public EditModel(ILogger<EditModel> logger)
    {
        _logger = logger;
    }

    class RemoteStorage
    {
        public static List<Game> Games = new();
    }

    public void OnPost(Game game)
    {
        NpgsqlCommand cmd =
            new("UPDATE game SET title = @Title, developer = @Developer, genre = @Genre where id = @Id");
        cmd.Parameters.AddWithValue("@Id", game.Id);
        cmd.Parameters.AddWithValue("@Title", game.Title);
        cmd.Parameters.AddWithValue("@Developer", game.Developer);
        cmd.Parameters.AddWithValue("@Genre", game.Genre);
    }

    public List<Game> GetGames()
    {
        return RemoteStorage.Games;
    }

    public void FillData(int gameId)
    {
        const string conn = "Host=localhost;Port=5432;Database=forlabs;Username=postgres;Password=1234";
        var npgsqlConnection = new NpgsqlConnection(conn);
        npgsqlConnection.Open();
        var cmd = new NpgsqlCommand("SELECT * FROM game", npgsqlConnection);
        var reader = cmd.ExecuteReader();
        if (!reader.HasRows) return;
        RemoteStorage.Games = new List<Game>();
        foreach (DbDataRecord line in reader)
        {
            Game g = new()
            {
                Id = line.GetInt32(3),
                Title = line.GetString(0),
                Developer = line.GetString(1),
                Genre = line.GetString(2)
            };
            if (g.Id == gameId)
                RemoteStorage.Games.Add(g);
        }

        npgsqlConnection.Close();
    }
}