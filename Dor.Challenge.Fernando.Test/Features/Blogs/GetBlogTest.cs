using Dor.Challenge.Fernando.App.Features.Blog.Requests;
using Dor.Challenge.Fernando.Domain.Persistance.Entities;
using Dor.Challenge.Fernando.Infra.Persistance;

namespace Dor.Challenge.Fernando.Test.Features.Blogs
{
    [Collection(nameof(TestFixture))]
    public class GetBlogTest
    {
        private readonly GetBlogHandler handler;

        public GetBlogTest(TestFixture fixture)
        {
            var service = new Service<BlogEntity>(fixture.repository);
            handler = new GetBlogHandler(fixture.mapper, service);
        }

        [Fact]
        public async void GetBlog_NoParametersSent_ShouldReturnAll()
        {
            // Arrange
            var request = new GetBlogRequest();

            // Act
            var result = await handler.Handle(request, new CancellationToken());

            // Assert
            Assert.NotEmpty(result);
        }

        [Fact]
        public async void GetBlog_CorrectIdSent_ShouldReturnBlog()
        {
            // Arrange
            var request = new GetBlogRequest { ID = new List<int> { 1 } };

            // Act
            var result = await handler.Handle(request, new CancellationToken());

            // Assert
            Assert.NotEmpty(result);
            Assert.Equal(request.ID.Count(), result.Count());
        }

        [Fact]
        public async void GetBlog_WrongIdSent_ShouldReturnEmpty()
        {
            // Arrange
            var request = new GetBlogRequest { ID = new List<int> { 3 } };

            // Act
            var result = await handler.Handle(request, new CancellationToken());

            // Assert
            Assert.Empty(result);
        }
    }
}
