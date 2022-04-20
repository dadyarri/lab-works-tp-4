using Lab2.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Npgsql;
using System.Data.Common;

namespace Lab2.Pages
{
    public static class RemoteStorage
    {
        public static List<Game> games = new();
    }
    public class IndexModel : PageModel
    {


        [BindProperty]
        public Game Game { get; set; }

        public List<Game> GetGames()
        {
            return RemoteStorage.games;
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
                RemoteStorage.games = new List<Game>();
                foreach (DbDataRecord line in reader)
                {
                    Game g = new();
                    g.Title = line.GetString(0);
                    g.Developer = line.GetString(1);
                    g.Genre = line.GetString(2);
                    RemoteStorage.games.Insert(0, g);
                }
            }
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            RemoteStorage.games.Insert(0, Game);

            String conn = "Host=localhost;Port=5432;Database=forlabs;Username=postgres;Password=1234";
            NpgsqlConnection npgsqlConnection = new NpgsqlConnection(conn);
            npgsqlConnection.Open();
            NpgsqlCommand command = new NpgsqlCommand("INSERT INTO game(title, developer, genre) VALUES(@title, @developer, @genre)", npgsqlConnection);
            command.Parameters.AddWithValue("@title", Game.Title);
            command.Parameters.AddWithValue("@developer", Game.Developer);
            command.Parameters.AddWithValue("@genre", Game.Genre);
            command.ExecuteNonQuery();
            return Page();
        }

    }
}