using mainAPI.Configuration;
using mainAPI.Models;
using Npgsql;
using System.Data.Common;

namespace lw4API.DAO
{
    public class ArticleDAO : IDAO<Article>
    {
        private Database database;
        public List<Article> articles = new List<Article>();

        public ArticleDAO(IConfiguration configuration)
        {
            this.database = new Database(configuration);
        }

        public void Create(Article article)
        {
            NpgsqlCommand cmd = new NpgsqlCommand("INSERT INTO article (title, author, description, date) VALUES (" +
                "@Title, @Author, @Description, @Date)");
            cmd.Parameters.AddWithValue("@Title", article.Title);
            cmd.Parameters.AddWithValue("@Author", article.Author);
            cmd.Parameters.AddWithValue("@Description", article.Description);
            cmd.Parameters.AddWithValue("@Date", article.Date);

            database.ExecuteSQLRequest_withParams(cmd);
        }

        public List<Article> GetAll()
        {
            string sql = "SELECT * FROM article";
            database.ExecuteSQLRequest(sql);
            if (database.reader.HasRows)
            {
                foreach (DbDataRecord line in database.reader)
                {
                    Article article = new Article(line.GetString(0), line.GetString(1), line.GetString(2), line.GetDateTime(3));
                    articles.Insert(0, article);
                }

            }
            return articles;
        }
    }
}
