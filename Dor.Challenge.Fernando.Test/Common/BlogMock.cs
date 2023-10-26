using Dor.Challenge.Fernando.App.Features.Blog.Requests.Bodies;
using Dor.Challenge.Fernando.Domain.Persistance.Entities;
using System.Runtime.InteropServices;

namespace Dor.Challenge.Fernando.Test.Common
{
    public static class BlogMock
    {
        public static BlogBody BlogBodyMock([Optional] int? ID)
        {
            return new BlogBody
            {
                ID = ID,
                Title = "Title Test",
                Content = "Content Test",
                AuthorID = 1,
            };
        }

        public static IEnumerable<BlogEntity> BlogEntitiesMock()
        {
            yield return new BlogEntity
            {
                ID = 1,
                Title = "Title Test",
                Content = "Content Test",
                AuthorID = 1,
            };
            yield return new BlogEntity
            {
                ID = 2,
                Title = "Title Test2",
                Content = "Content Test2",
                AuthorID = 2,
            };
            yield return new BlogEntity
            {
                ID = 3,
                Title = "Title Test2",
                Content = "Content Test2",
                AuthorID = 1,
            };
        }
    }
}
