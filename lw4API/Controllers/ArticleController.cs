using mainAPI.DAO;
using mainAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace mainAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ArticleController : ControllerBase
    {
        readonly ArticleDAO articleDAO = new ArticleDAO(Configuration.Configuration.config);

        [HttpGet]
        public List<Article> GetArticle()
        {
            return articleDAO.GetAll();
        }

        [HttpPost]
        public void CreateArticle(Article article)
        {
            articleDAO.Create(article);
        }
    }
}