using lw4API.Configuration;
using lw4API.Models;
using Npgsql;
using System.Data.Common;

namespace lw4API.DAO
{
    public class ArticleDao : IDAO<Article>
    {
        private readonly Database _database;
        private readonly List<Article> _articles = new();

        public ArticleDao(IConfiguration configuration)
        {
            this._database = new Database(configuration);
        }

        public void Create(Article article)
        {
            NpgsqlCommand cmd = new NpgsqlCommand("INSERT INTO article (title, author, description, date) VALUES (" +
                                                  "@Title, @Author, @Description, @Date)");
            cmd.Parameters.AddWithValue("@Title", article.Title);
            cmd.Parameters.AddWithValue("@Author", article.Author);
            cmd.Parameters.AddWithValue("@Description", article.Description);
            cmd.Parameters.AddWithValue("@Date", article.Date);

            _database.ExecuteSQLRequest_withParams(cmd);
        }

        public List<Article> GetAll()
        {
            string sql = "SELECT * FROM article";
            _database.ExecuteSQLRequest(sql);
            if (_database.reader.HasRows)
            {
                foreach (DbDataRecord line in _database.reader)
                {
                    Article article = new Article(line.GetString(0), line.GetString(1), line.GetString(2),
                        line.GetDateTime(3));
                    _articles.Insert(0, article);
                }
            }

            return _articles;
        }
    }
}