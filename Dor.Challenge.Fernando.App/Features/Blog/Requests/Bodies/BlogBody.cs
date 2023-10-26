namespace Dor.Challenge.Fernando.App.Features.Blog.Requests.Bodies
{
    public class BlogBody
    {
        public int? ID { get; init; }
        public string? Title { get; init; }
        public string? Content { get; init; }
        public int AuthorID { get; init; }
    }
}
