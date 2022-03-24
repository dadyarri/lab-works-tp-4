using Lab2.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Lab2.Pages
{
    public class IndexModel : PageModel
    {
        public string? Mes { get; set; }
        [BindProperty]
        public Game Game { get; set; }


        public void OnGet()
        {
            Mes = "Hello";
        }

        public void OnPost()
        {
            if (ModelState.IsValid)
            {
                Shelf.shelf.Add(Game);
            }
        }

    }
}