namespace lw4API.Models
{
    public class Article
    {
        public Article(string title, string author, string description, DateTime date)
        {
            Title = title;
            Author = author;
            Description = description;
            Date = date;
        }

        public string Title { get; set; }
        public string Author { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
    }
}
