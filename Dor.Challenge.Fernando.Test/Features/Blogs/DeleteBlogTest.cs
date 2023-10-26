using Dor.Challenge.Fernando.App.Features.Blog.Requests;
using Dor.Challenge.Fernando.Domain.Exceptions;
using Dor.Challenge.Fernando.Domain.Persistance.Entities;
using Dor.Challenge.Fernando.Infra.Persistance;

namespace Dor.Challenge.Fernando.Test.Features.Blogs
{
    [Collection(nameof(TestFixture))]
    public class DeleteBlogTest
    {
        private readonly DeleteBlogHandler handler;

        public DeleteBlogTest(TestFixture fixture)
        {
            var service = new Service<BlogEntity>(fixture.repository);
            handler = new DeleteBlogHandler(service);
        }

        [Fact]
        public async void DeleteBlog_CorrectIdSent_ShouldDeleteBlog()
        {
            // Arrange
            var request = new DeleteBlogRequest { ID = 3 };

            // Act
            await handler.Handle(request, new CancellationToken());

            // Assert
            Assert.True(true);
        }

        [Fact]
        public async void DeleteBlog_IncorrectIdSent_ShouldThrowException()
        {
            // Arrange
            var request = new DeleteBlogRequest { ID = 0 };

            // Act
            async Task func() { await handler.Handle(request, new CancellationToken()); }

            // Assert
            await Assert.ThrowsAsync<NotFoundApiException>(func);
        }
    }
}
