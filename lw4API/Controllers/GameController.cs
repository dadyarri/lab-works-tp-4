using lw4API.DAO;
using lw4API.Models;
using Microsoft.AspNetCore.Mvc;

namespace lw4API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GameController : ControllerBase
    {
        readonly GameDao _gameDao = new(Configuration.Configuration.config);

        [HttpGet]
        public List<Game> GetGames()
        {
            return _gameDao.GetAll();
        }

        [HttpPost]
        public void CreateGame(Game game)
        {
            _gameDao.Create(game);
        }
    }
}