using lw4API.DAO;
using lw4API.Models;
using Microsoft.AspNetCore.Mvc;

namespace lw4API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ArticleController : ControllerBase
    {
        readonly ArticleDao _articleDAO = new(Configuration.Configuration.config);

        [HttpGet]
        public List<Article> GetArticle()
        {
            return _articleDAO.GetAll();
        }

        [HttpPost]
        public void CreateArticle(Article article)
        {
            _articleDAO.Create(article);
        }
    }
}