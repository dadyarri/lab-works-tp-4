namespace lw4API.Models
{
    public class Game
    {
        public Game(string title, string developer, string genre)
        {
            Title = title;
            Developer = developer;
            Genre = genre;
        }

        public string Title { get; set; }
        public string Developer { get; set; }
        public string Genre { get; set; }
    }
}
