using System.ComponentModel.DataAnnotations;

namespace lw4Web.Models
{
    public class Game
    {
        [Required(ErrorMessage = "Название должно быть заполнено")]
        public string Title { get; init; }
        [Required(ErrorMessage = "Разработчик должен быть заполнен")]
        [MaxLength(50)]
        public string Developer { get; init; }
        [Required(ErrorMessage = "Введите жанр")]
        public string Genre { get; init; }
    }
}
