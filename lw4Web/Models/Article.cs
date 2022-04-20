using System.ComponentModel.DataAnnotations;

namespace mainWeb.Models
{
    public class Article
    {
        [Required(ErrorMessage = "Заголовок обязательно должен быть заполнен")]
        [MaxLength(30)]
        [MinLength(3, ErrorMessage = "Длина заголовка должна превышать 3 символа")]
        public string Title { get; set; }
        [Required(ErrorMessage = "Автор обязательно должен быть заполнен")]
        [MaxLength(50)]
        public string Author { get; set; }
        [Required(ErrorMessage = "Введите описанаие статьи")]
        public string Description { get; set; }
        [Required]
        public DateTime Date { get; set; }
    }
}
