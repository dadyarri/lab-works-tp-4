using lw4Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace lw4Web.Pages
{
    public class ViewStore
    {
        public static List<Game> Games = new();
    }

    public class GameModel : PageModel
    {
        private HttpClient? _client;

        public GameModel(HttpClient client)
        {
            _client = client;
        }

        [BindProperty] public Game Game { get; set; }

        public async void OnGet()
        {
            if (_client is not null)
            {
                ViewStore.Games = await _client.GetFromJsonAsync<List<Game>>("http://localhost:5124/Game");
            }
        }

        public async void OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return;
            }

            ViewStore.Games.Insert(0, Game);
            if (_client is not null)
            {
                HttpResponseMessage response = await _client.PostAsJsonAsync("http://localhost:5124/Game", Game);
            }
        }

        public List<Game> GetGames()
        {
            return ViewStore.Games;
        }
    }
}