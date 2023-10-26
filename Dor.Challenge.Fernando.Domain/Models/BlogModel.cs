namespace Dor.Challenge.Fernando.Domain.Models
{
    public class BlogModel
    {
        public int ID { get; set; }
        public string? Title { get; set; }
        public string? Content { get; set; }
        public AuthorModel? Author { get; set; }
    }
}
