using Microsoft.AspNetCore.Mvc.RazorPages;

namespace lw1.Pages
{
    public class IndexModel : PageModel
    {
        public float Answer { get; set; }
        public bool Error { get; set; }

        public int x, y;

        public bool IsCalculated { get; set; }

        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
            IsCalculated = false;
        }

        public void OnGet() { }

        public void OnPost(string firstValue, string secondValue, string operation)
        {
            if (int.TryParse(firstValue, out x) && int.TryParse(secondValue, out y)) {
                switch (operation)
                {
                    case "add":
                        Answer = x + y;
                        break;
                    case "sub":
                        Answer = x - y;
                        break;
                    case "mul":
                        Answer = x * y;
                        break;
                    case "div":
                        Answer = x / y;
                        break;
                }
                Error = false;
            } else
            {
                Error = true;
            }
            IsCalculated = true;
        }
    }
}