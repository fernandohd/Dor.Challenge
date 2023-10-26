namespace Dor.Challenge.Fernando.Domain.Models
{
    public class AuthorModel
    {
        public int ID { get; set; }
        public string? Name { get; set; }
        public string? Nationality { get; set; }
        public ICollection<BlogModel>? Blogs { get; set; }
    }
}
