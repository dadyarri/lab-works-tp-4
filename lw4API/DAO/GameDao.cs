using lw4API.Configuration;
using lw4API.Models;
using Npgsql;
using System.Data.Common;

namespace lw4API.DAO
{
    public class GameDao : IDao<Game>
    {
        private readonly Database _database;
        private readonly List<Game> _games = new();

        public GameDao(IConfiguration configuration)
        {
            _database = new Database(configuration);
        }

        public void Create(Game game)
        {
            NpgsqlCommand cmd = new("INSERT INTO game (title, developer, genre, date) VALUES (" +
                                    "@Title, @Developer, @Genre)");
            cmd.Parameters.AddWithValue("@Title", game.Title);
            cmd.Parameters.AddWithValue("@Developer", game.Developer);
            cmd.Parameters.AddWithValue("@Genre", game.Genre);

            _database.ExecuteSQLRequest_withParams(cmd);
        }

        public List<Game> GetAll()
        {
            string sql = "SELECT * FROM game";
            _database.ExecuteSqlRequest(sql);
            if (_database.Reader is not null && _database.Reader.HasRows)
            {
                foreach (DbDataRecord line in _database.Reader)
                {
                    Game game = new Game(line.GetString(0), line.GetString(1), line.GetString(2));
                    _games.Insert(0, game);
                }
            }

            return _games;
        }
    }
}