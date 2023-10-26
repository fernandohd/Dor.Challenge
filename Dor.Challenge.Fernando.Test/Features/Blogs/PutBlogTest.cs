using Dor.Challenge.Fernando.App.Features.Blog.Requests;
using Dor.Challenge.Fernando.Domain.Exceptions;
using Dor.Challenge.Fernando.Domain.Persistance.Entities;
using Dor.Challenge.Fernando.Infra.Persistance;

namespace Dor.Challenge.Fernando.Test.Features.Blogs
{
    [Collection(nameof(TestFixture))]
    public class PutBlogTest
    {
        private readonly PutBlogHandler handler;

        public PutBlogTest(TestFixture fixture)
        {
            var service = new Service<BlogEntity>(fixture.repository);
            handler = new PutBlogHandler(fixture.mapper, service);
        }

        [Fact]
        public async void PutBlog_CorrectBodySent_ShouldUpdateBlog()
        {
            // Arrange
            var request = new PutBlogRequest { Body = BlogMock.BlogBodyMock(1) };

            // Act
            await handler.Handle(request, new CancellationToken());

            // Assert
            Assert.True(true);
        }

        [Fact]
        public async void PutBlog_IncorrectBodySent_ShouldThrowException()
        {
            // Arrange
            var request = new PutBlogRequest { Body = BlogMock.BlogBodyMock(0) };

            // Act
            async Task func() { await handler.Handle(request, new CancellationToken()); }

            // Assert
            await Assert.ThrowsAsync<NotFoundApiException>(func);
        }
    }
}
