using mainWeb.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Text.Json;

namespace mainWeb.Pages
{
    public class ViewStore
    {
        public static List<Article> articles = new List<Article>();
    }
    public class BlogModel : PageModel
    {
        private HttpClient client;
        public BlogModel (HttpClient client)
        {
            this.client = client;
        }

        [BindProperty]
        public Article article { get; set; }
        public async void OnGet()
        {
            ViewStore.articles = await client.GetFromJsonAsync<List<Article>>("http://localhost:5124/Article");
        }

        public async void OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return;
            }
            article.Date = DateTime.Now;
            ViewStore.articles.Insert(0, article);
            HttpResponseMessage response = await client.PostAsJsonAsync("http://localhost:5124/Article", article);

        }

        public List<Article> GetArticles()
        {
            return ViewStore.articles;
        }
    }
}
