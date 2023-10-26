using Dor.Challenge.Fernando.App.Features.Author.Requests;
using Dor.Challenge.Fernando.Domain.Exceptions;
using Dor.Challenge.Fernando.Domain.Persistance.Entities;
using Dor.Challenge.Fernando.Infra.Persistance;

namespace Dor.Challenge.Fernando.Test.Features.Authors
{
    [Collection(nameof(TestFixture))]
    public class DeleteAuthorTest
    {
        private readonly DeleteAuthorHandler handler;

        public DeleteAuthorTest(TestFixture fixture)
        {
            var service = new Service<AuthorEntity>(fixture.repository);
            handler = new DeleteAuthorHandler(service);
        }

        [Fact]
        public async void DeleteAuthor_CorrectIdSent_ShouldDeleteAuthor()
        {
            // Arrange
            var request = new DeleteAuthorRequest { ID = 2 };

            // Act
            await handler.Handle(request, new CancellationToken());

            // Assert
            Assert.True(true);
        }

        [Fact]
        public async void DeleteAuthor_IncorrectIdSent_ShouldThrowException()
        {
            // Arrange
            var request = new DeleteAuthorRequest { ID = 0 };

            // Act
            async Task func() { await handler.Handle(request, new CancellationToken()); }

            // Assert
            await Assert.ThrowsAsync<NotFoundApiException>(func);
        }
    }
}
