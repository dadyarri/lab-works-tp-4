using System.ComponentModel.DataAnnotations;

namespace lw4Web.Models
{
    public class Game
    {
        [Required(ErrorMessage = "Название должно быть заполнено")]
        [MaxLength(30)]
        public string Title { get; init; }
        [Required(ErrorMessage = "Автор обязательно должен быть заполнен")]
        [MaxLength(50)]
        public string Developer { get; init; }
        [Required(ErrorMessage = "Введите описанаие статьи")]
        public string Genre { get; }
    }
}
