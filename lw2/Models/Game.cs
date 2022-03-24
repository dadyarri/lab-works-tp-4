using System.ComponentModel.DataAnnotations;

namespace Lab2.Models
{
    public class Game
    {
        [Required(ErrorMessage ="Title is required")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Developer is required")]
        public string Developer { get; set; }

        [Required(ErrorMessage = "Genre is required")]
        public string? Genre{ get; set; }
    }
}
