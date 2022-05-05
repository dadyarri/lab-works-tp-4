using System.Data.Common;
using lw5.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Npgsql;

namespace lw5.Views.Home;

public class IndexModel: PageModel
{
    class RemoteStorage
    {
        public static List<Game> Games = new();
    }
    public void OnGet()
    {
        String conn = "Host=localhost;Port=5432;Database=forlabs;Username=postgres;Password=1234";
        NpgsqlConnection npgsqlConnection = new NpgsqlConnection(conn);
        npgsqlConnection.Open();
        NpgsqlCommand command = new NpgsqlCommand("SELECT * FROM game", npgsqlConnection);
        NpgsqlDataReader reader = command.ExecuteReader();
        if (reader.HasRows)
        {
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
                RemoteStorage.Games.Add(g);
            }
        }
    }

    public List<Game> GetGames()
    {
        return RemoteStorage.Games;
    }
}