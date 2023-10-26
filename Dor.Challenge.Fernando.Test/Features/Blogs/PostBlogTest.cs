using Dor.Challenge.Fernando.App.Features.Blog.Requests;
using Dor.Challenge.Fernando.Domain.Persistance.Entities;
using Dor.Challenge.Fernando.Infra.Persistance;

namespace Dor.Challenge.Fernando.Test.Features.Blogs
{
    [Collection(nameof(TestFixture))]
    public class PostBlogTest
    {
        private readonly PostBlogHandler handler;

        public PostBlogTest(TestFixture fixture)
        {
            var service = new Service<BlogEntity>(fixture.repository);
            handler = new PostBlogHandler(fixture.mapper, service);
        }

        [Fact]
        public async void PostBlog_CorrectBodySent_ShouldAddAndReturnBlog()
        {
            // Arrange
            var request = new PostBlogRequest { Body = BlogMock.BlogBodyMock() };

            // Act
            var result = await handler.Handle(request, new CancellationToken());

            // Assert
            Assert.NotNull(result);
            Assert.NotEqual(0, result.ID);
        }
    }
}
